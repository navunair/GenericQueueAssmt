using GenericQueueAssmt;

GenericQueue<Chat> gqueue = new GenericQueue<Chat>(10);

int msgId = 0;
bool run = true;

while (run)
{
    Console.WriteLine("Queue Operations:");
    Console.WriteLine("1. Enqueue");
    Console.WriteLine("2. Dequeue");
    Console.WriteLine("3. Check if Empty");
    Console.WriteLine("4. Check if Full");
    Console.WriteLine("5. Exit");
    Console.Write("Input: ");

    var inp = Convert.ToInt32(Console.ReadLine());

    switch (inp)
    {
        case 1:
            Console.WriteLine("Enter message");
            string content = Console.ReadLine();
            gqueue.enqueue(new Chat
            {
                MessageId = ++msgId,
                Content = content,
                TimeStamp = DateTime.Now,
                SourceId = msgId
            });
            Console.WriteLine("ChatMessage enqueued.");
            break;
        case 2:
            Chat dequeuedMessage = gqueue.dequeue();
            if (dequeuedMessage == null)
            {
                Console.WriteLine("No message in queue");
                break;
            }
            Console.WriteLine($"Dequeued message: ID {dequeuedMessage.MessageId}, Content: {dequeuedMessage.Content}, TimeStamp: {dequeuedMessage.TimeStamp}, SourceId: {dequeuedMessage.SourceId}");
            break;
        case 3:
            Console.WriteLine(gqueue.IsEmpty());
            break;
        case 4:
            Console.WriteLine(gqueue.IsFull());
            break;
        case 5:
            return;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}
