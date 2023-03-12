using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace BitwiseOperations 
{
    public class BitboardCreator : MonoBehaviour
    {
        [SerializeField] List<GameObject> tilePrefabs = new List<GameObject>();
        [SerializeField] GameObject housePrefab;
        [SerializeField] GameObject treePrefab;
        [SerializeField] Text score;

        List<GameObject> tiles = new List<GameObject>();
        long dirBitboard = 0;

        private void Start()
        {
            CreateRandomBitboard();
        }

        void CreateRandomBitboard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    int randomTile = UnityEngine.Random.Range(0, tilePrefabs.Count);
                    Vector3 position = new Vector3(column, 0, row);
                    GameObject tile = Instantiate(tilePrefabs[randomTile], position, Quaternion.identity);

                    tile.name = $"{tile.tag} (Row: {row}, Column: {column})";

                    if (tile.CompareTag(GameTag.Dirt))
                    {
                        dirBitboard = SetCellState(dirBitboard, row, column);
                        PrintBitboard("Drit", dirBitboard);
                    }

                    tiles.Add(tile);
                }
            }

            Debug.Log($"Dirt cells = {CellCount(dirBitboard)}");
        }

        void PrintBitboard(string name, long bitboard)
        {
            Debug.Log($"{name} : {Convert.ToString(bitboard, 2).PadLeft(64, '0')}");
        }

        long SetCellState(long bitboard, int row, int col)
        {
            long newBitboard = 1L << (row * 8 * col);

            return (bitboard |= newBitboard);
        }

        bool GetCellState(long bitboard, int row, int col)
        {
            long mask = 1L << (row * 8 * col);

            return ((bitboard & mask) != 0);
        }

        int CellCount(long bitboard)
        {
            int count = 0;
            long localBitboard = bitboard;
            
            while (localBitboard != 0)
            {
                localBitboard &= localBitboard - 1;
                count++;
            }

            return count;
        }

        void PlantTree()
        {
            int randomRow = UnityEngine.Random.Range(0, 8);
        }

        private void Update()
        {
            
        }
    }
}