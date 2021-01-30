using System;

namespace _02.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int patients;
            int treatedPatients = 0;
            int untreatedPatients = 0;

            int doctors = 7;

            for (int i = 1; i <= days; i++)
            {
                patients = int.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    if (treatedPatients < untreatedPatients)
                    {
                        doctors++;
                    }

                    if (patients >= doctors)
                    {
                        treatedPatients = treatedPatients + doctors;
                        untreatedPatients = untreatedPatients + (patients - doctors);
                    }
                    else
                    {
                        treatedPatients = treatedPatients + patients;
                    }

                }
                else
                {
                    if (patients >= doctors)
                    {
                        treatedPatients = treatedPatients + doctors;
                        untreatedPatients = untreatedPatients + (patients - doctors);
                    }
                    else
                    {
                        treatedPatients = treatedPatients + patients;
                    }

                }
            }
            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
