using System.Collections.Generic;
using System.Linq;

namespace Teste
{
    public class Arvore
    {
        public List<No> Nos { get; set; }

        public Arvore()
        {
            this.Nos = new List<No>();
        }

        public void InserirNo(string pai, string filho)
        {
            var noInserido = false;

            foreach (var no in this.Nos)
            {
                noInserido = no.Processar(no, pai, filho);
                if (noInserido)
                    break;
            }

            if (!noInserido)
                this.InserirNoRaiz(pai, filho);
        }

        private void InserirNoRaiz(string pai, string filho)
        {
            var raiz = new No();
            raiz.InserirNoRaiz(raiz, pai, filho);

            Nos.Add(raiz);
        }

        public bool BalancearArvore(No pai, string filho)
        {
            var noFilho = StaticData.Tree.Nos.FirstOrDefault(raiz => raiz.Letra == filho);
            if (noFilho != null)
            {
                pai.VincularNoFilhoAoNoPai(pai, noFilho);
                StaticData.Tree.Nos.Remove(noFilho);
                return true;
            }
            foreach (var no in Nos)
            {
                var noMovimentado = no.Movimentar(pai, filho);
                if (noMovimentado)
                    return true;
            }

            return false;
        }

        public bool VerificaArvoreCiclica(No no, string filho)
        {
            return false;
        }

        public string ExibirArvoreMontada()
        {
            var raiz = Nos.FirstOrDefault();
            return raiz.ExibirArvoreMontada();
        }
    }
}