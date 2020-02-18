using System;
﻿using Akka.Actor;

namespace WinTail
{
    #region Program
    class Program
    {
        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {

            // Initialize actor system
            MyActorSystem = ActorSystem.Create("MyActorSystem");

            // Make the actors
            IActorRef consoleWriterActor = MyActorSystem.ActorOf(Props.Create(() => new ConsoleWriterActor()), "consoleWriterActor");
            IActorRef tailCoordinatorActor = MyActorSystem.ActorOf(Props.Create(() => new TailCoordinatorActor()), "tailCoordinatorActor");
            // pass tailCoordinatorActor to fileValidatorActorProps (just adding one extra arg)
            IActorRef validationActor = MyActorSystem.ActorOf(
                Props.Create(() => new FileValidatorActor(consoleWriterActor, tailCoordinatorActor))
                ,"validationActor"
                );
            IActorRef consoleReaderActor = MyActorSystem.ActorOf(Props.Create<ConsoleReaderActor>(validationActor), "consoleReaderActor");

            // tell console reader to begin
            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

            // blocks the main thread from exiting until the actor system is shut down
            MyActorSystem.WhenTerminated.Wait();
        }


    }
    #endregion
}
