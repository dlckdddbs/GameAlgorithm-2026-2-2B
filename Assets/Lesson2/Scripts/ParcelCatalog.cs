using AlgoCourse.Lesson2;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public sealed class ProductCatalog : IParcelCatalog
{
    //01: 가상 Bucket 수를 5로 정함.
    private const int NumberOfBuckets = 5;

    //02: int Key와 ParcelProductInfo Value를 저장할 Dictionary를 생성
    private readonly Dictionary<int, ParcelProductInfo> products = new Dictionary<int, ParcelProductInfo>();

    public int BucketCount => NumberOfBuckets;

    // TODO 03: 현재 상품 수를 반환합니다.
    public int Count => products.Count;

    public void Initialize()
    {
        // 04: Dictionary를 비우고 상품 1001-1006을 Register로 등록
        products.Clear();

        Register(1001, "세제", 0);
        Register(1002, "키보드", 1);
        Register(1003, "시계", 2);
        Register(1004, "수건", 0);
        Register(1005, "마우스", 1);
        Register(1006, "보석함", 2);
    }

    public bool Register(int id, string productName, int destinationIndex)
    {
        //05: 중복 Key는 false를 반환하고 새 상품만 등록
        if (products.ContainsKey(id))
        {
            return false;
        }

        ParcelProductInfo product = new ParcelProductInfo(id, productName, destinationIndex);

        products.Add(id, product);

        return true;
    }


    public bool Contains(int id)
    {
        return products.ContainsKey(id);
    }

    public bool TryFind(int id, out ParcelProductInfo product)
    {
        return products.TryGetValue(id, out product);
    }

    public int GetHash(int id)
    {
        // 08 : key의 hash값을 반환
        return id.GetHashCode();
    }

    public int GetBucketIndex(int id)
    {
        // 09 양수 Hash를 Bucket 수로 나눈 나머지를 반환.
        int hash = GetHash(id);
        int positiveHash = hash & 0x7FFFFFFF;           //비트 연산으로 Hash의 부호 비트를 제거 하는 역할                
        return positiveHash % NumberOfBuckets;
    }

    public bool HasCollision(int id)
    {
        int targetBucket = GetBucketIndex(id);

        foreach(int key in products.Keys)
        {
            if (key == id)      //자기 자신은 제외
            {
                continue;
            }

            if (GetBucketIndex(key) == targetBucket)
            {
                return true;
            }
        }

        return false;
    }

    public bool ChangeDestination(int id, int newDestinationIndex)
    {
        // 11. 기존 상품을 찾아 목적지 value를 교체

        if(!products.TryGetValue(id, out ParcelProductInfo oldProduct))
        {
            return false;
        }

        ParcelProductInfo newProduct = new ParcelProductInfo(oldProduct.Id, oldProduct.ProductName, newDestinationIndex);

        products[id] = newProduct;

        return true;
    }

    public int CountByDestination(int destinationIndex)
    {

        int count = 0; 

        foreach(ParcelProductInfo product in products.Values)
        {
            if(product.DestinationIndex == destinationIndex)
            count++;
        }
        return 0;
    }

    public bool Remove(int id)
    {
        return products.Remove(id); 
    }


}
