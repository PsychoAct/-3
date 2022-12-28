using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WindowsFormsApp1
{
    public class Modeling
    {
        public int time = 0;
        public float sumconnection;
        static Random rnd = new Random();
        public List<int> AllCon= new List<int>();     
        public float AllConN;
        public int mincon;
        public float UcrCol;
        public float UcrSig;
        public void startmodeling(List<CompNetw> LCom_Net, List<MovingObject> LMov_Obj,int Delta_Time)
        {
            
            for (time = 0; time < Delta_Time; time++)
            {

                for (int i = 0; i < LMov_Obj.Count; i++)
                {
                    mincon = 100;
                   
                    for (int j = 0; j < LCom_Net.Count; j++)
                    {
                        
                        if (Math.Abs(LMov_Obj[i].coordinate - LCom_Net[j].coordinate) <= LCom_Net[j].maxradius &&    //сначала идет проверка на макс радиус и кол-во соединений у сети
                            LCom_Net[j].numberOfCon < LCom_Net[j].MaxConnected                          
                           )
                        {
                                for (int k = 0; k < LCom_Net.Count; k++)
                                if (mincon >= Math.Abs(LMov_Obj[i].coordinate - LCom_Net[k].coordinate))
                                    mincon = Math.Abs(LMov_Obj[i].coordinate - LCom_Net[k].coordinate);

                            if (mincon == Math.Abs(LMov_Obj[i].coordinate - LCom_Net[j].coordinate))       //подключаемся к сети с лучшей связью
                            {                               
                                LCom_Net[j].numberOfCon += 1;
                                sumconnection += 1;
                                int MatAbs = Math.Abs(LMov_Obj[i].coordinate - LCom_Net[j].coordinate);//Кач-во соединения
                                AllCon.Add(MatAbs);
                                AllConN += MatAbs;
                            }
                        }
                        // создаем 3 цикла, 1 цикл- основной, 2- на обьект, 3- на сеть. в 3 цикле проверяем кол-во соединений если оно равно 2,
                        // то ничего не делаем, переходим к другому обькту, но
                        //но и он не может подключится т.к. обновляем мы подключения в 1 цикле, и если меньше 2 подключений, то подключаем итый обьект к итой сети,                       
                        // также суммируем все подключения чтобы потом найти статистику по ним, с качеством соединения тоже самое, но с ним уже создаем массив,
                        // так как нам нужно сохранять каждое подключение,
                        //в конце обнуляем connection и ставим новые координаты обьектам
                        //
                        
                    }
                    
                    
                }
                

                for (int i = 0; i < LMov_Obj.Count; i++)//obj get new coordinate;
                {
                    int NewCoordinate = rnd.Next(1, 100);
                    LMov_Obj[i].coordinate = NewCoordinate;
                    
                }
                for(int i=0;i<LCom_Net.Count;i++)  //connection=0
                LCom_Net[i].numberOfCon = 0;
            }           
            UcrCol = (sumconnection / LCom_Net.Count()); //Статистика, ср кол-во объектов подключ к сети, усредненных по сети
            UcrSig = (AllConN/LMov_Obj.Count());         //ср уровень сигнала у объекта
        }
    }

}
