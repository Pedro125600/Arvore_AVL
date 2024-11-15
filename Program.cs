﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att1
{
    class Program
    {
        static void Main(string[] args)
        {


        }

    }

    class No
    {
        private int elemento;
        private No esq;
        private No dir;
        public No(int elemento)
        {
            this.elemento = elemento;
            esq = null;
            dir = null;
        }
        public No(int elemento, No esq, No dir)
        {
            this.elemento = elemento;
            this.esq = esq;
            this.dir = dir;
        }

        public No Esq
        {
            get { return esq; }
            set { this.esq = value; }
        }

        public No Dir
        {
            get { return dir; }
            set { this.dir = value; }
        }

        public int Elemento
        {
            get { return elemento; }
            set { this.elemento = value; }
        }




    }

    class ArvoreBinaria
    {
        public No raiz;


        public ArvoreBinaria() { raiz = null; }


        public bool Rotaçãodupla(No i)
        {

            if(i.Esq != null && i.Esq.Dir != null && i.Dir == null)
            {
                //RotacaoduplaESQ
            }
            else if(i.Dir != null && i.Dir.Esq != null && i.Esq == null)
            {
                //RotacaoduplaESQ
            }
        }

        private int AlturaArvore(No i)
        {
          if(i == null) { return 0; }

            int altesq = AlturaArvore(i.Esq);
            int altdir = AlturaArvore(i.Dir);

            if (altesq > altdir)
            {
                return 1 + altesq;
            }
            else
            {
                return 1 + altdir;
            }
        }


        public int FatorBalanceamento(No i)
        {

            return AlturaArvore(i.Esq) - AlturaArvore(i.Dir);
       
        }



        public void Balancear(No i)
        {

            if (i != null)
            {
                if (FatorBalanceamento(i) <= -2)
                {
                    //RotacaodiR
                }
                else if(FatorBalanceamento(i) >= 2)
                {
                    //RotaçãoEsQ
                }


                Balancear(i.Esq);

                if (FatorBalanceamento(i) <= -2)
                {
                    //RotacaodiR
                }
                else if (FatorBalanceamento(i) >= 2)
                {
                    //RotaçãoEsQ
                }

                Balancear(i.Dir);
               

            }
        }


        public void Inserir(int x)
        {
            raiz = Inserir(x, raiz);
        }
        private No Inserir(int x, No i)
        {
            if (i == null)
            {
                i = new No(x);
            }
            else if (x < i.Elemento)
            {
                i.Esq = Inserir(x, i.Esq);
            }
            else if (x > i.Elemento)
            {
                i.Dir = Inserir(x, i.Dir);
            }
            else
            {
                throw new Exception("Erro!");
            }
            return i;
        }


        public void CaminharPre()
        {
            CaminharPre(raiz);
        }

        private void CaminharPre(No i)
        {
            if (i != null)
            {
                Console.Write(i.Elemento + " ");
                CaminharPre(i.Esq);
                CaminharPre(i.Dir);
            }
        }
        public void CaminharCentral()
        {
            CaminharCentral(raiz);
        }

        private void CaminharCentral(No i)
        {
            if (i != null)
            {
                CaminharCentral(i.Esq);
                Console.Write(i.Elemento + " ");
                CaminharCentral(i.Dir);
            }
        }

        public bool Pesquisar(int x)
        {
            return Pesquisar(x, raiz);
        }
        private bool Pesquisar(int x, No i)
        {
            bool resp;
            if (i == null)
            {
                resp = false;
            }
            else if (x == i.Elemento)
            {
                resp = true;
            }
            else if (x < i.Elemento)
            {
                resp = Pesquisar(x, i.Esq);
            }
            else
            {
                resp = Pesquisar(x, i.Dir);
            }
            return resp;
        }

      

        public void CaminharPos()
        {
            CaminharPos(raiz);
        }
        private void CaminharPos(No i)
        {
            if (i != null)
            {
                CaminharPos(i.Esq);
                CaminharPos(i.Dir);
                Console.Write(i.Elemento + " ");
            }
        }

        public int ContarNoFolha(int resp)
        {
            return ContarNoFolha(raiz, ref resp);
        }

        private int ContarNoFolha(No i, ref int resp)
        {

            if (i != null)
            {
                ContarNoFolha(i.Esq, ref resp);
                if (i.Esq == null && i.Dir == null)
                    return resp++;

                ContarNoFolha(i.Dir, ref resp);
                if (i.Esq == null && i.Dir == null)
                    return resp++;

            }

            return resp;

        }
    }

}

