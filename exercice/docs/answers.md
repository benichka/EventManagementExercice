# Answers for the exercices
Those are the answers for [this](./readme.md).
## Going further
#### Delegate to handle event
1. an event that will not provide data:
```csharp
public delegate void OutOfBeansHandler(object sender, EventArgs e);
public event OutOfBeansHandler OutOfBeans;
```
can be replaced by:
```csharp
public event EventHandler OutOfBeans;
```
1. an event that will provide data:
```csharp
public delegate void VendingMachineNotificationHandler(object sender, VendingMachineNotificationEventArgs e);
public event VendingMachineNotificationHandler VendingMachineNotification;
```
can be replaced by:
```csharp
public event EventHandler<VendingMachineNotificationEventArgs> VendingMachineNotification;
```

#### Checking the nullity of an event before raising it
1. We have to check if the event is not null before firing it because an event is considered null if it has no subscriber.
1. The instanciation of a local object prevent the *NullReferenceException* in a multithreaded execution. Indeed, the null check can be realised and *then* a subscriber unsubscribe the event.  
As an event is immutable, doing a local copy will prevent it to be null if it wasn't before.
