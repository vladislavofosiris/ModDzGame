using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDZGame1
{
    #region Bag
    public class Bag: IEnumerable<Artifact>
    {
        private List<Artifact> _bag;
        private int _totalSpace;
        private int _freeSpace;

        public Bag (int Space)
        {
            _bag = new List<Artifact>();
            _totalSpace = Space;
            _freeSpace = Space;
        }
        
        #region Add
        public void Add(Artifact artifact)
        {
            if (_freeSpace >= artifact.Weigth)
            {
                _bag.Add(artifact);
                _freeSpace -= artifact.Weigth;
            }
            else
            {
                Console.WriteLine($"Error: Bag is full");
            }
        }
        #endregion

        #region Remove

        public void Remove(int index)
        {
            if (index <=_bag.Count)
            {
                _freeSpace += _bag[index - 1].Weigth;
                _bag.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine($"Error: Number not found");
            }            
        }
        public Artifact this[int index]
        {
            get => _bag[index];
            set => _bag[index] = value;
        }
        #endregion

        public IEnumerator<Artifact> GetEnumerator ()
        {
            return _bag.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _bag.GetEnumerator();
        }
        
    }
    #endregion
}
