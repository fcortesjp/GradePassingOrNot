using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradePassingOrNot
{
    class Program
    {
        static public int getNumberOfGrades()
        {
            int grades = 0;
            while (true)
            {
                Console.Write("Ingrese numero de notas: ");
                string numberOfGradesStr = Console.ReadLine();

                // revise si el numero de notas esta en blanco o nulo
                if (string.IsNullOrWhiteSpace(numberOfGradesStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: el numero de notas no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el numero de notas puede ser un numero entero
                bool canBeInt = int.TryParse(numberOfGradesStr, out grades);
                if (canBeInt == false)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no es valido");
                    //regrese al inicio del loop
                    continue;
                }
                //revise si el numero es negativo o cero
                if (grades <= 0)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no puede ser negativo o cero");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }

            return grades;
        }

        static public double[] getGrades(int numberOfGrades)
        {
            //define el array para guardar notas
            double[] gradesArray = new double[numberOfGrades];

            //por cada nota...
            for (int i = 0; i < gradesArray.Length; i++)
            {
                //definimos variables iniciales
                string gradeStr = "";
                double grade = 0.0;

                //pedimos las notas y validamos cada input
                while (true)
                {
                    Console.Write("Ingrese nota numero " + (i + 1) + ": ");
                    gradeStr = Console.ReadLine();

                    // revise si la nota esta en blanco o nulo
                    if (string.IsNullOrWhiteSpace(gradeStr))
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: la nota no puede estar en blanco");
                        //regrese al inicio del loop
                        continue;
                    }
                    // revise si el la puede ser un numero decimal
                    bool canBeDouble = double.TryParse(gradeStr, out grade);
                    if (canBeDouble == false)
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: El dato ingresado no es valido");
                        //regrese al inicio del loop
                        continue;
                    }
                    //revise si el numero es negativo
                    if (grade < 0 || grade > 5)
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: El dato ingresado no puede ser negativo o mayor de 5");
                        //regrese al inicio del loop
                        continue;
                    }
                    // si no hay problemas con la captura salga del loop
                    break;
                }
                //guarde la nota  en el array;
                gradesArray[i] = grade;
            }
            return gradesArray;
        }

        static public void getPassingAndAverage(double[] gradesArray)
        {
            //defina variables contadoras y para calculos finales
            int passing = 0;
            int notPassing = 0;
            double gradeSum = 0.0;
            for (int i = 0; i < gradesArray.Length; i++)
            {
                if (gradesArray[i] >= 3) //si pasa 
                {
                    passing++; //sume
                }
                else //si no pasa
                {
                    notPassing++; //sume tambien
                }
                gradeSum += gradesArray[i]; //acumelo las notas 
            }
            //Muestre en pantalla totales
            Console.WriteLine("Pasan: " + passing);
            Console.WriteLine("Pierden: " + notPassing);
            Console.WriteLine("Promedio:  {0:N2}", gradeSum/gradesArray.Length);
        }
        
            static void Main(string[] args)
        {
            //obtenga el numero total de notas a procesar
            int numberOfGrades = getNumberOfGrades();
            //obtenga y valide cada nota
            double[] grades = getGrades(numberOfGrades);
            //muestre resultados
            getPassingAndAverage(grades);
            Console.WriteLine("Presione enter para finalizar...");
            Console.ReadLine();
        }
    }
}
