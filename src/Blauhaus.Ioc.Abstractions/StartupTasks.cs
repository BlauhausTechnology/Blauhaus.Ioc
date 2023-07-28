using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blauhaus.Ioc.Abstractions;

//collection of tasks that can be registered with a container to be run when the container is ready 
public class StartupTasks : List<Func<Task>>
{
    public StartupTasks(params Func<Task>[] tasks) : base(tasks) { }
}