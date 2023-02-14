using System;

namespace Teste
{
    class StaticData
    {
        public static Arvore Tree = new Arvore();
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Cenários
            var values = "[A,B] [A,C] [B,G] [C,H] [E,F] [B,D] [C,E]";
            //var values = "[B,D] [D,E] [A,B] [C,F] [E,G] [A,C]";
            //var values = "[A,B] [A,C] [B,D] [D,C]";

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Array de Entrada: {values}");
            Console.WriteLine("");

            try
            {
                Executar(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exceção: E4 - " + ex.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }

        static void Executar(string values)
        {
            var arvore = StaticData.Tree;
            var valuesToLoop = GetValues(values);

            for (int i = 0; i < valuesToLoop.Length - 1; i += 2)
            {
                var pai = valuesToLoop[i].ToString();
                var filho = valuesToLoop[i + 1].ToString();

                arvore.InserirNo(pai, filho);
            }

            if (arvore.Nos.Count == 0)
                throw new Exception("E4 - Árvore sem raiz");

            else if (arvore.Nos.Count > 1)
                throw new Exception("E3 - Raízes múltiplas");

            Console.WriteLine("Árvore Montada: " + arvore.ExibirArvoreMontada());
        }

        static string GetValues(string values)
        {
            return values.Replace("[", "").Replace("]", "").Replace(",", "").Replace(" ", "");
        }
    }
}
