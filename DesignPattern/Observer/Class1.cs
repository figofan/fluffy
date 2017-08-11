using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    class Class1 : IObserver<int>
    {
	    public void OnNext(int value)
	    {
		    throw new NotImplementedException();
	    }

	    public void OnError(Exception error)
	    {
		    throw new NotImplementedException();
	    }

	    public void OnCompleted()
	    {
		    throw new NotImplementedException();
	    }
    }

	class Class2 : IObservable<int>
	{
		public IDisposable Subscribe(IObserver<int> observer)
		{
			throw new NotImplementedException();
		}
	}
}
