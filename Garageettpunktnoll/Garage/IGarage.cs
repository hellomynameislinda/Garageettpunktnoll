namespace Garageettpunktnoll
{
    internal interface IGarage
    {
        string GarageName { get; }
        int MaxCapacity { get; }

        bool IsEmpty();
        bool IsFull();
        bool RegistrationAvailable(string registrationNo);
        bool UpdateMaxCapacity(int maxCapacity);
    }
}