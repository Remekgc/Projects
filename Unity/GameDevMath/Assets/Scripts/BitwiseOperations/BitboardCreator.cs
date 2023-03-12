using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;

namespace BitwiseOperations 
{
    public class BitboardCreator : MonoBehaviour
    {
        [SerializeField] List<GameObject> tilePrefabs = new List<GameObject>();
        [SerializeField] GameObject housePrefab;
        [SerializeField] GameObject treePrefab;
        [SerializeField] Text score;

        GameObject[] tiles;
        long dirBitboard = 0;
        long treeBitboard = 0;
        long playerBitboard = 0;
        long desertBitboard = 0;

        private void Start()
        {
            CreateRandomBitboard();
        }

        void CreateRandomBitboard()
        {
            tiles = new GameObject[64];

            for (int row = 0; row < 8; ++row)
            {
                for (int column = 0; column < 8; ++column)
                {
                    int randomTile = UnityEngine.Random.Range(0, tilePrefabs.Count);
                    Vector3 position = new Vector3(column, 0, row);
                    GameObject tile = Instantiate(tilePrefabs[randomTile], position, Quaternion.identity);
                    tile.name = $"{tile.tag} (Row: {row}, Column: {column})";
                    tiles[row * 8 + column] = tile;

                    if (tile.CompareTag(GameTag.Dirt))
                    {
                        dirBitboard = SetCellState(dirBitboard, row, column);
                        //PrintBitboard("Drit", dirBitboard);
                    }
                    else if (tile.CompareTag(GameTag.Desert))
                    {
                        desertBitboard = SetCellState(desertBitboard, row, column);
                        //PrintBitboard("Desert", desertBitboard);
                    }
                }
            }

            Debug.Log($"Dirt cells = {CellCount(dirBitboard)}");
            StartCoroutine(IPlantTrees());
        }

        IEnumerator IPlantTrees()
        {
            for (int i = 0; i < 50; i++)
            {
                PlantTree();
                yield return new WaitForSeconds(.25f);
            }
        }

        void PrintBitboard(string name, long bitboard)
        {
            Debug.Log($"{name} : {Convert.ToString(bitboard, 2).PadLeft(64, '0')}");
        }

        long SetCellState(long bitboard, int row, int col)
        {
            long newBitboard = 1L << (row * 8 + col);

            return (bitboard |= newBitboard);
        }

        bool GetCellState(long bitboard, int row, int col)
        {
            long mask = 1L << (row * 8 + col);

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

        void CalculateScore()
        {
            score.text = $"Score: {(CellCount(dirBitboard & playerBitboard) * 10) + (CellCount(desertBitboard & playerBitboard) * 2)}";
        }

        void PlantTree()
        {
            int randomRow = UnityEngine.Random.Range(0, 8);
            int randomColumn = UnityEngine.Random.Range(0, 8);

            if (GetCellState(dirBitboard & ~(playerBitboard | treeBitboard), randomRow, randomColumn))
            {
                GameObject tree = Instantiate(treePrefab);

                tree.transform.parent = tiles[randomRow * 8 + randomColumn].transform;
                tree.transform.localPosition = Vector3.zero;

                treeBitboard = SetCellState(treeBitboard, randomRow, randomColumn);
            }
        }

        private void Update()
        {
            ManageInput();
        }

        void ManageInput() 
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100f))
                {
                    Transform hitTransform = hit.collider.transform;
                    int row = (int)hitTransform.position.z;
                    int column = (int)hitTransform.position.x;

                    if (GetCellState((dirBitboard & ~treeBitboard) | desertBitboard, row, column))
                    {
                        GameObject house = Instantiate(housePrefab);
                        house.transform.parent = hit.collider.gameObject.transform;
                        house.transform.localPosition = Vector3.zero;

                        playerBitboard = SetCellState(playerBitboard, row, column);

                        CalculateScore();
                    }
                }
            }
        }

    }
}