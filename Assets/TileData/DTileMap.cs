using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DTileMap  {

    protected class DRoom
    {
        public int left;
        public int top;
        public int width;
        public int height;
        public bool isConnected = false;

        public int right { get { return left + width - 1; } }
        public int bottom { get { return top + height - 1; } }
        public int center_x { get { return left + width / 2; } }
        public int center_y { get { return top + height / 2; } }

        public bool CollidesWith(DRoom other)
        {
            if (left > other.right -1 ) return false;
            if (top > other.bottom -1 ) return false;
            if (right < other.left +1 ) return false;
            if (bottom < other.top +1 ) return false; 
            else return true;
        }
    }

    int size_x;
    int size_y;
    public int[,] map_data;
    //TDTile[,] tile_data;
    List<DRoom> rooms;
    

    public DTileMap(int size_x, int size_y)
    {
        this.size_x = size_x;
        this.size_y = size_y;

        map_data = new int[size_x, size_y];

        for(int x =0; x<size_x; x++)
        {
            for (int y = 0; y<size_y; y++)
            {
                map_data[x, y] = 3;
                //TDTile tile = new TDTile(TILE_TYPE.EMPTY);
                //tile.prefab = Instantiate( ) ;
                //tile_data[x, y] = tile;
            }
        }

        rooms = new List<DRoom>();

        for (int i = 0; i < 15; i++) { 
            int rsx = Random.Range(8, 12);
            int rsy = Random.Range(8, 10);
            DRoom r = new DRoom();
            r.left = Random.Range(0,size_x - rsx);
            r.top = Random.Range(0, size_y - rsy);
            r.width = rsx;
            r.height = rsy;

            if (!RoomCollides(r))
            {
                rooms.Add(r);
                MakeRoom(r);
            }
        }
        MakeCorridor(rooms[0], rooms[1]);

       
        for( int i =0; i <rooms.Count; i++)
        {
            if (!rooms[i].isConnected)
            {
                int j = Random.Range(1,i - 1);
                MakeCorridor(rooms[i], rooms[(i + j) % rooms.Count]);
            }
        }

        MakeWalls();

    }

    bool RoomCollides(DRoom r)
    {
        foreach(DRoom r2 in rooms)
        {
            if (r.CollidesWith(r2))
            {
                return true;
            }
        }
        return false;
    }

    public int GetTyleAt(int x, int y)
    {
        return map_data[x, y];
    }

    void MakeRoom(DRoom r)
    {
        for (int x = 0; x < r.width; x++) {
            for (int y = 0; y < r.height; y++) {
                if (x == 0 || x ==r.width-1 ||y==0 || y == r.height - 1){
                    map_data[r.left + x, r.top + y] = 2;
                }
                else {
                    map_data[r.left + x, r.top + y] = 1;
                }
            }
        }
    }

    void MakeCorridor(DRoom r1, DRoom r2)
    {
        int x = r1.center_x;
        int y = r1.center_y;

        while (x != r2.center_x)
        {
            map_data[x, y] = 1;
            x += x < r2.center_x ? 1 : -1;//Move x dir
        }
        while(y != r2.center_y)
        {    
            map_data[x, y] = 1;
            y += y < r2.center_y ? 1 : -1;//Move y dir
        }
        r1.isConnected = true;
    }

    void MakeWalls()
    {
        for (int x = 0; x<size_x;x++)
        {
            for (int y = 0; y < size_y; y++)
            {
                if(map_data[x,y] ==3 && HasAdjacentFloor(x,y))
                {
                    map_data[x, y] = 2;
                }
            }
        }
    }

    bool HasAdjacentFloor(int x, int y)
    {
        if (x > 0          && map_data[x - 1, y] == 1) return true;
        if (x > size_x - 1 && map_data[x + 1, y] == 1) return true;
        if (y > 0          && map_data[x ,y - 1] == 1) return true;
        if (y > size_y - 1 && map_data[x ,y + 1] == 1) return true;

        if (x > 0         && y > 0 && map_data[x - 1, y - 1] == 1) return true;
        if (x < size_x-1  && y > 0 && map_data[x + 1, y - 1] == 1) return true;

        if (x > 0          && y < size_y - 1 && map_data[x - 1, y + 1] == 1) return true;
        if (x < size_x - 1 && y < size_y - 1 && map_data[x + 1, y + 1] == 1) return true;

        return false;
    }




}
