using Abstract_Method.Interfaces;

internal interface IFactory
{
    IProductA CreateProductA();

    IProductB CreateProductB();
}