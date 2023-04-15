using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaServices
{
    static List<Pizza>? Pizzas { get; }
    // static int NextId = 3;
    static PizzaServices()
    {
        Pizzas = new List<Pizza>() {
            new Pizza() { Id=1, Name="Classic Italian", IsGlutenFree=false },
            new Pizza() { Id=2, Name="Veggie", IsGlutenFree=false }
        };
    }
    public static List<Pizza> GetAll() => Pizzas!;
    public static Pizza Get(int id) => Pizzas!.FirstOrDefault(item => item.Id == id)!;
    public static void Add(Pizza pizza)
    {
        var lastId = Pizzas!.Last().Id +1;
        pizza.Id = lastId;
        Pizzas!.Add(pizza);
    }
    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza == null)
            return;
        Pizzas!.Remove(pizza);
    }
    public static void Update(Pizza pizza)
    {
        var index = Pizzas!.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
        {
            return;
        }
        Pizzas[index] = pizza;
    }
}