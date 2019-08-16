using System;

namespace PSO
{
    class Program
    {
        static void Main(string[] args)
        {
            PSO(5, 0.8, 0.5, 1, 8);
        }

        //O fator de inércia, fator cognitivo e fator social normalmente são contantes entre 0 e +1
        //O índice representa a partícula 0, 1 e 2
        public static void PSO(int tempoMax, double fatorDeInercia, double fatorCognitivo, double fatorSocial, double velocidadeMaxima)
        {
            //O índice de X representa as partículas [0, 1, 2]
            //Os valores representam a posição
            double[] X = { 1, 10, 15 };
            //O índice de V representa as partículas [0, 1, 2]
            //Os valores representam a velocidade
            double[] V = { 5, 4, 3 };
            //O índice de P representa as partículas [0, 1, 2]
            //Os valores representam a melhor posição da partícula
            double[] P = { 1, 10, 15 };

            double Pg = 0;

            double t = 0;

            while (t < tempoMax)
            {
                Console.WriteLine($"Instante: {t}");
                Console.WriteLine($"Vetor de posições:              {X[0]}; {X[1]}; {X[2]}");
                Console.WriteLine($"Vetor de Velocidades:           {V[0]}; {V[1]}; {V[2]}");
                Console.WriteLine($"Vetor de Melhores Posições:     {P[0]}; {P[1]}; {P[2]}");
                Console.WriteLine($"Melhor Performance Geral:       {Pg}");
                Console.ReadLine();
                //For que percorre o vetor de particulas
                for (int i = 0; i < X.Length; i++)
                {

                    if (Performance(X[i]) > Performance(P[i]))
                        P[i] = X[i];

                    //For que compara a partícula i com as vizinhas
                    for (int j = 0; j < X.Length; j++)
                    {
                        if (j == i) ;
                        else if (Performance(X[j]) > Performance(Pg))
                            Pg = X[j];
                    }
                    //Conta que representa o pensamento da partícula sobre sua posição atual, sua melhor posição e a melhor posição dos seus vizinhos
                    var novaVelocidade = fatorDeInercia * V[i] + fatorCognitivo * (P[i] - X[i]) + fatorSocial * (Pg - X[i]);
                    //Mantém a velocidade dentro do escopo
                    novaVelocidade = novaVelocidade > velocidadeMaxima ? velocidadeMaxima : novaVelocidade < -velocidadeMaxima ? -velocidadeMaxima : novaVelocidade;
                    //Cálculo da nova posição baseado na novaVelocidade
                    X[i] = X[i] + novaVelocidade;
                    //Armazena nova velocidade
                    V[i] = novaVelocidade;
                }

                t++;
            }
            Console.ReadLine();
        }

        private static double Performance(double posicao)
        {
            if(posicao > 14 && posicao <= 19 )
            {
                return 10;
            }
            else if(posicao > 19 && posicao < 22)
            {
                return 20;
            }
            else 
            {
                return 0;
            }
        }
    }
}
