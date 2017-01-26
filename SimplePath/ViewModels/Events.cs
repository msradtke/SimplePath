using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using SimplePath.Models;
namespace SimplePath.ViewModels
{
    public class LineAddedEvent : PubSubEvent<LinePath> { }
}
