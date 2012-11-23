using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> processors;
    ICreateTheCommandWhenOneCantBeFound missing_command_factory;

    public CommandRegistry(IEnumerable<IProcessOneRequest> processors,
                           ICreateTheCommandWhenOneCantBeFound missing_command_factory)
    {
      this.processors = processors;
      this.missing_command_factory = missing_command_factory;
    }

  	public CommandRegistry():this(new StubSetOfCommands(), null)
  	{
  		
  	}
    public IProcessOneRequest get_the_command_that_can_process(IContainRequestDetails request)
    {
      var match = processors.FirstOrDefault(c => c.can_process(request));

      return match ?? missing_command_factory();
    }
  }
}