using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    //10 - Crie o construtor de `Rent` seguindo as regras de negócio
    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        Vehicle = vehicle;
        Person = person;
        DaysRented = daysRented;
        Status = RentStatus.Confirmed;
        vehicle.IsRented = true;

        if (person.GetType().GetProperty("CPF") != null)
        { Price = vehicle.PricePerDay * daysRented; }

        if (person.GetType().GetProperty("CNPJ") != null)
        { Price = vehicle.PricePerDay * daysRented * 0.9; }

        person.Debit = Price;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel()
    {
        Status = RentStatus.Canceled;
        Person.Debit = 0;
        Vehicle.IsRented = false;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        Status = RentStatus.Finished;
        Vehicle.IsRented = false;
    }
}