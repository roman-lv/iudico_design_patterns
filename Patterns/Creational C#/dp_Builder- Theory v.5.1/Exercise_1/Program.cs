using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    abstract class MazeBuilder
    {
        public MazeBuilder() { }

        public abstract void BuildMaze();
        public abstract void BuildRoom(int room);
        public abstract void BuildDoor(int roomFrom, int roomTo);

        public Maze GetMaze() { return null; }

    };

    class Maze
    {
        private List<int> rooms = new List<int>();
        private List<KeyValuePair<int, int>> doors = new List<KeyValuePair<int, int>>();

        public bool existRoomNo(int x)
        {
            for (int i = 0; i < rooms.Count; ++i)
            {
                if (rooms[i] == x)
                {
                    return true;
                }
            }
            return false;
        }
        public void addRoom(int x)
        {
            rooms.Add(x);
        }
        public void addDoor(int x, int y)
        {
            doors.Add(new KeyValuePair<int, int>(x, y));
        }

        public void print()
        {
            Console.Write("Rooms : ");
            for (int i = 0; i < rooms.Count; ++i)
            {
                Console.Write(String.Format("{0}  ", rooms[i]));
            }
            Console.WriteLine();
            Console.WriteLine("Doors between rooms:");
            for (int i = 0; i < doors.Count; ++i)
            {
                Console.WriteLine(String.Format("{0}  {1}", doors[i].Key, doors[i].Value));
            }
        }
    };

    class StandardMazeBuilder : MazeBuilder
    {
        public StandardMazeBuilder()
        {
            _currentMaze = null;
        }

        public override void BuildMaze()
        {
            _currentMaze = new Maze();
        }
        public override void BuildRoom(int n)
        {
            if (!_currentMaze.existRoomNo(n))
            {
                _currentMaze.addRoom(n);
            }
        }
        public override void BuildDoor(int x, int y)
        {
            if (_currentMaze.existRoomNo(x) && _currentMaze.existRoomNo(y))
            {
                _currentMaze.addDoor(x, y);
            }
        }

        public Maze GetMaze()
        {
            return _currentMaze;
        }


        private Maze _currentMaze;
    };

    class CountingMazeBuilder : MazeBuilder
    {
        public override void BuildMaze()
        {
        }
        public Maze GetMaze()
        {
            throw new NotImplementedException();
        }
        public CountingMazeBuilder()
        {
            _rooms = _doors = 0;
        }

        public override void BuildRoom(int n)
        {
            _rooms++;
        }
        public override void BuildDoor(int x, int y)
        {
            _doors++;
        }

        public void GetCounts(out int rooms, out int doors)
        {

            rooms = _rooms;
            doors = _doors;
        }

        private int _doors;
        private int _rooms;
    };

    class MazeGame
    {
        public void createMaze(MazeBuilder builder)
        {
            builder.BuildMaze();
            builder.BuildRoom(1);
            builder.BuildRoom(2);
            builder.BuildDoor(1, 2);
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Standard game : ");
            Maze mazeStandard = new Maze();
            MazeGame gameStandard = new MazeGame();
            StandardMazeBuilder builderStandard = new StandardMazeBuilder();

            gameStandard.createMaze(builderStandard);
            mazeStandard = builderStandard.GetMaze();

            mazeStandard.print();

            Console.WriteLine();

            Console.WriteLine("Counting game : ");

            int rooms, doors;
            MazeGame gameCounting = new MazeGame();
            CountingMazeBuilder builderCounting = new CountingMazeBuilder();

            gameCounting.createMaze(builderCounting);
            builderCounting.GetCounts(out rooms, out doors);

            Console.WriteLine(String.Format("The maze has {0} rooms and {1} doors", rooms, doors));

            Console.ReadKey();
        }
    }
}
