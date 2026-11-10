using System.Collections.Generic;
using AlgoLesson8;

namespace AlgoLesson8.Student
{
    /// <summary>
    /// 제작법 그래프를 탐색해 재료부터 완제품까지의 생산 순서를 만듭니다.
    /// </summary>
    public sealed class ProductionPlanner : IProductionPlanner
    {
        public ProductionPlan BuildPlan(
            string targetProduct,
            IReadOnlyList<RecipeDefinition> recipes)
        {
           ProductionPlan result = new ProductionPlan();

        Dictionary<string, RecipeDefinition> recipeMap = new Dictionary<string, RecipeDefinition>();

            foreach (RecipeDefinition recipe in recipes)
            {
                    recipeMap[recipe.Output] = recipe;
            }

            //DFS 상태 집합 준비

            HashSet<string> visited = new HashSet<string>();
            HashSet<string> visiting = new HashSet<string>();

            //목표 제품에서 시작해 필요한 재료를 거슬러 내려가며 탐색
            Visit(targetProduct, recipeMap, visited, visiting, result);

            return result;
        }

        //후위 순회 (재료들을 먼저 모두 처리한뒤 product 하나를 DFS로 방문
        private static void Visit(string product, Dictionary<string, RecipeDefinition> recipeMap,
            HashSet<string> visited, HashSet<string> visiting, ProductionPlan result)
        {
            if (result.HasCycle || visited.Contains(product)) return;        //이미 사이클이 발견 됐으면 종료

            if (!visiting.Add(product))
            {
                result.HasCycle = true;
                return;
            }

            if (recipeMap.TryGetValue(product, out RecipeDefinition recipe))        //모든 재료를 먼저 방문하고 레시피가 없승면 원재료로 취급
            {
                foreach (string input in recipe.Inputs)
                    Visit(input, recipeMap, visited, visiting, result);
            }

            visiting.Remove(product);
            visited.Add(product);

            result.Steps.Add(product);  //모든 재료가 이미 step 에 들어간 뒤이므로 여기서 추가 하면 재료 -> 결과물 순서가 보장 된다.
        }
    }
}
