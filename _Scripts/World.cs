using UnityEngine;
using System.Collections.Generic;

public class World
{
    WorldData worldData;
    public Tile[,] GetWorldData(Player player,int distance)
    {
        Tile[,] t = new Tile[ distance, distance];

        var startX = (int)(player.viewPosition.x) - distance;
        var endX = (int)(player.viewPosition.x) + distance;

        var startZ = (int)(player.viewPosition.y) - distance;
        var endZ = (int)(player.viewPosition.y) + distance;

        var _x = 0;
        var _z = 0;

        for(int i = startX;i<endX;i++)
        {
            for(int j = startZ;j<endZ;j++)
            {
                t[_x,_z] = worldData.tiles[i,j];
            }
        }

        return t;
    }
    
}

public enum TileContent
{
    building,
    urban_center,
    rock,
    rock_mine,
    gold,
    gold_mine,
    forest,
    lumberjack,
    pipe,
}

public struct Tile
{
    public List<TileContent> content;
    public bool ground;
}

public class WorldData
{
    public Tile[,] tiles;
    

}