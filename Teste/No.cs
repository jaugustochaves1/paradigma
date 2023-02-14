using System;
using System.Text;

namespace Teste
{
    public class No
    {
        public No(string letra) => Letra = letra;
        public No() { }

        public string Letra { get; private set; }
        public No Esquerda { get; private set; }
        public No Direita { get; private set; }

        public bool ExisteNoFilhoNaEsquerda() => this.Esquerda is not null;

        public bool ExisteNoFilhoNaDireita() => this.Direita is not null;


        public void VincularNoFilhoAoNoPai(No pai, No filho)
        {
            if (!pai.ExisteNoFilhoNaEsquerda())
                pai.Esquerda = filho;

            else if (!pai.ExisteNoFilhoNaDireita())
                pai.Direita = filho;

            else
                throw new Exception($"E1 - Múltiplos Filhos do No {pai.Letra}");
        }

        private bool InserirNoFilho(No no, string filho)
        {
            if (StaticData.Tree.VerificaArvoreCiclica(no, filho))
                throw new Exception($"E2 - Ciclo presente para filho {filho}");

            var arvoreBalanceada = StaticData.Tree.BalancearArvore(no, filho);
            if (arvoreBalanceada)
                return true;

            VincularNoFilhoAoNoPai(no, new No(filho));
            return true;
        }

        public void InserirNoRaiz(No no, string pai, string filho)
        {
            no.Letra = pai;
            InserirNoFilho(no, filho);
        }

        public bool Processar(No no, string pai, string filho)
        {
            if (no.Letra == pai)
                return InserirNoFilho(no, filho);

            if (no.ExisteNoFilhoNaEsquerda())
            {
                if (Processar(no.Esquerda, pai, filho))
                    return true;
            }

            if (no.ExisteNoFilhoNaDireita())
            {
                if (Processar(no.Direita, pai, filho))
                    return true;
            }

            return false;
        }

        public bool Movimentar(No destino, string filho)
            => Movimentar(this, null, destino, filho);

        private bool Movimentar(No atual, No pai, No destino, string filho)
        {
            if (atual.Letra == filho)
            {
                VincularNoFilhoAoNoPai(destino, atual);

                if (pai.ExisteNoFilhoNaEsquerda() && pai.Esquerda.Letra == filho)
                    pai.Esquerda = null;

                if (pai.ExisteNoFilhoNaDireita() && pai.Direita.Letra == filho)
                    pai.Direita = null;

                return true;
            }

            if (atual.ExisteNoFilhoNaEsquerda())
            {
                if (Movimentar(atual.Esquerda, atual, destino, filho))
                    return true;
            }

            if (atual.ExisteNoFilhoNaDireita())
            {
                if (Movimentar(atual.Direita, atual, destino, filho))
                    return true;
            }

            return false;
        }


        public string ExibirArvoreMontada()
            => ExibirArvoreMontada(this, "");

        private string ExibirArvoreMontada(No no, string space)
        {
            var str = new StringBuilder();
            str.AppendLine("");
            str.Append($"{space} {no.Letra}");
            if (no.ExisteNoFilhoNaEsquerda() || no.ExisteNoFilhoNaDireita())
            {
                if (no.ExisteNoFilhoNaEsquerda())
                    str.Append(ExibirArvoreMontada(no.Esquerda, space + "--"));

                if (no.ExisteNoFilhoNaDireita())
                {
                    str.Append(ExibirArvoreMontada(no.Direita, space + "--"));
                }
            }

            return str.ToString();
        }
    }
}