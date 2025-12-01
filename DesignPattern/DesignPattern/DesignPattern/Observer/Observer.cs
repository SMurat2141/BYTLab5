// In case you need some guidance: https://refactoring.guru/design-patterns/observer

namespace DesignPattern.Observer
{
    public class ConcreteObserver(string userName) : IObserver
    {
        public string UserName { get; } = userName;
        private ISubject? _subject;

        // 3. Registering the Observer with the Subject
        public void AddSubscriber(ISubject subject)
        {
            _subject = subject;
            subject.RegisterObserver(this);
        }

        // 4. Removing the Observer from the Subject
        public void RemoveSubscriber(ISubject subject)
        {
            subject.RemoveObserver(this);
            if (ReferenceEquals(_subject, subject))
            {
                _subject = null;
            }
        }

        // 5. Observer will get a notification from the Subject using this Method
        public void Update(string availability) =>
            Console.WriteLine($"Hello {UserName}, product availability changed to: {availability}");
    }
}