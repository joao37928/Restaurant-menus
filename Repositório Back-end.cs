using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criação de um sócio
            Socio socio = new Socio(1, "João Silva");

            // Criação de consumos
            Consumo consumo1 = new Consumo("Café", 5.0);
            Consumo consumo2 = new Consumo("Sanduíche", 15.0);

            // Criação de uma mesa e adição de consumos
            Mesa mesa = new Mesa(101, socio.Id, 1001, 10, DateTime.Now);
            mesa.AdicionarConsumo(consumo1);
            mesa.AdicionarConsumo(consumo2);

            // Exibição das informações
            Console.WriteLine(socio);
            Console.WriteLine(consumo1);
            Console.WriteLine(consumo2);
            Console.WriteLine(mesa);

            // Remover um consumo e exibir novamente
            mesa.RemoverConsumo(consumo1);
            Console.WriteLine("Após remover o consumo de Café:");
            Console.WriteLine(mesa);

            // Criação de uma comanda e adição de consumos
            Comanda comanda = new Comanda(1, 1001, 10, DateTime.Now, socio);
            comanda.AdicionarConsumo(consumo1);
            comanda.AdicionarConsumo(consumo2);

            // Exibição das informações da comanda
            Console.WriteLine(comanda);
        }
    }

    // Classe Socio
    public class Socio
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Socio(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Socio{{id={Id}, nome='{Nome}'}}";
        }
    }

    // Classe Consumo
    public class Consumo
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }

        public Consumo(string descricao, double valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"Consumo{{descricao='{Descricao}', valor={Valor}}}";
        }
    }

    // Classe Mesa
    public class Mesa
    {
        public int Numero { get; private set; }
        public int IdSocio { get; private set; }
        public int IdFuncionario { get; private set; }
        public int IdRestaurante { get; private set; }
        public DateTime Data { get; private set; }
        private List<Consumo> Consumos { get; set; }

        public Mesa(int numero, int idSocio, int idFuncionario, int idRestaurante, DateTime data)
        {
            Numero = numero;
            IdSocio = idSocio;
            IdFuncionario = idFuncionario;
            IdRestaurante = idRestaurante;
            Data = data;
            Consumos = new List<Consumo>();
        }

        public void AdicionarConsumo(Consumo consumo)
        {
            Consumos.Add(consumo);
        }

        public void RemoverConsumo(Consumo consumo)
        {
            Consumos.Remove(consumo);
        }

        public double CalcularTotal()
        {
            return Consumos.Sum(c => c.Valor);
        }

        public override string ToString()
        {
            return $"Mesa{{numero={Numero}, idSocio={IdSocio}, idFuncionario={IdFuncionario}, idRestaurante={IdRestaurante}, data={Data}, total={CalcularTotal()}}}";
        }
    }

    // Classe Comanda
    public class Comanda
    {
        public int Numero { get; private set; }
        public int IdFuncionario { get; private set; }
        public int IdRestaurante { get; private set; }
        public DateTime Data { get; private set; }
        public Socio Socio { get; private set; }
        private List<Consumo> Consumos { get; set; }

        public Comanda(int numero, int idFuncionario, int idRestaurante, DateTime data, Socio socio)
        {
            Numero = numero;
            IdFuncionario = idFuncionario;
            IdRestaurante = idRestaurante;
            Data = data;
            Socio = socio;
            Consumos = new List<Consumo>();
        }

        public void AdicionarConsumo(Consumo consumo)
        {
            Consumos.Add(consumo);
        }

        public double CalcularTotal()
        {
            return Consumos.Sum(c => c