using System.Collections.Generic;
using AlgoCourse.Lesson2;

namespace AlgoCourse.StudentWork
{
    public sealed class ProductCatalog : IParcelCatalog
    {
        // TODO 01: 가상 Bucket 수를 5로 정합니다.
        private const int NumberOfBuckets = 0;

        // TODO 02: int Key와 ParcelProductInfo Value를 저장할 Dictionary를 생성합니다.
        private readonly Dictionary<int, ParcelProductInfo> products = null;

        public int BucketCount => NumberOfBuckets;

        // TODO 03: 현재 상품 수를 반환합니다.
        public int Count => 0;

        public void Initialize()
        {
            // TODO 04: Dictionary를 비우고 상품 1001~1006을 Register로 등록합니다.
        }

        public bool Register(int id, string productName, int destinationIndex)
        {
            // TODO 05: 중복 Key는 false를 반환하고 새 상품만 등록합니다.
            return false;
        }

        public bool Contains(int id)
        {
            // TODO 06: ContainsKey로 등록 여부를 반환합니다.
            return false;
        }

        public bool TryFind(int id, out ParcelProductInfo product)
        {
            // TODO 07: TryGetValue로 안전하게 상품을 조회합니다.
            product = default;
            return false;
        }

        public int GetHash(int id)
        {
            // TODO 08: Key의 Hash 값을 반환합니다.
            return 0;
        }

        public int GetBucketIndex(int id)
        {
            // TODO 09: 양수 Hash를 Bucket 수로 나눈 나머지를 반환합니다.
            return 0;
        }

        public bool HasCollision(int id)
        {
            // TODO 10: 같은 Bucket을 사용하는 다른 Key가 있는지 검사합니다.
            return false;
        }

        public bool ChangeDestination(int id, int newDestinationIndex)
        {
            // TODO 11: 기존 상품을 찾아 목적지 Value를 교체합니다.
            return false;
        }

        public int CountByDestination(int destinationIndex)
        {
            // TODO 12: 같은 목적지를 가진 Value의 개수를 셉니다.
            return 0;
        }

        public bool Remove(int id)
        {
            // TODO 13: 상품을 삭제하고 성공 여부를 반환합니다.
            return false;
        }
    }
}
