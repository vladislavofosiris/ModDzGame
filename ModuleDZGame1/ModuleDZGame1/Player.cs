using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDZGame1
{
    #region PlayerClass
    public class CharactericticEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
    public class Player
    {
     
        public Bag Bag;
        private int _health;
        private int _power;
        private int _mn;
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }
        public int Power
        {
            get
            {
                return _power;
            }
            set
            {
                _power = value;
            }
        }
        public int Mn
        {
            get
            {
                return _mn;
            }
            set
            {
                _mn = value;
            }
        }
        public Player( int _health, int _power, int _mn, int BagSize)
        {
            Health = _health;
            Power = _power;
            Mn = _mn;
            Bag = new Bag(BagSize);
        }
        
        #endregion


        #region Step
        public void Step(int damage)
        {            
            Console.ReadKey();
            int a=new Random().Next(1,4);         
                      
               
                if (a == 1)
                {
                    Health -= damage ;
                }
                if (a == 2)
                {
                    Power -= damage;
                }
                if (a == 3)
                {
                    Mn-= damage;
                }
                Console.WriteLine($"Health:{Health}");
                Console.WriteLine($"Power:{Power}");
                Console.WriteLine($"Mn:{ Mn}");
                Console.ReadKey();
            
            

        }
        public delegate void CharacteristicChangedEventHandler(object source, CharactericticEventArgs args);

        public event CharacteristicChangedEventHandler CharacteristicChanged;

        private void CharacteristicIncreasing(string characteristic, double previousValue, double currentValue)
        {
            CharacteristicChanged?.Invoke(this, new CharactericticEventArgs { Message = $"{characteristic} +{currentValue - previousValue}" });
        }

        private void CharacteristicDecreasing(string characteristic, double previousValue, double currentValue)
        {
            CharacteristicChanged?.Invoke(this, new CharactericticEventArgs { Message = $"{characteristic} {currentValue - previousValue}" });
        }
    }
    #endregion
}
