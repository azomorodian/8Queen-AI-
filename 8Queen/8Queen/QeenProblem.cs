using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Queen
{
    class QeenProblem
    {
        public int [] State= new int[8];
        public int Depth;
        public int PathCost;
        public int[] action = new int[2];
        public int row;
        public List<QeenProblem> successors = new List<QeenProblem>();
        public QeenProblem Parrent;
        public void CreateSuccessors()
        {
            successors.Clear();
            for (int i = 0; i < 8; i++)
            {
                QeenProblem n = new QeenProblem();
                n.Depth = Depth + 1;
                n.row = row + 1;
                n.PathCost = PathCost + 1;
                n.Parrent = this;
                n.action[0] = row;
                n.action[1] = i;
                for (int j = 0; j < 8; j++)
                    n.State[j] = State[j];
                n.State[row] = i;
                successors.Add(n);
            }
        }

    }
}
