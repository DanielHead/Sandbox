using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace UnitTestingExample.UI.ServiceChannelFactory
{
    public abstract class ServiceProxyBase<T> : IDisposable where T : class
    {

        private readonly string _endpointName;

        private readonly object _sync = new object();

        private IChannelFactory<T> _channelFactory;

        private T _channel;

        private bool _disposed;



        protected ServiceProxyBase(string endpointName)
        {

            _endpointName = endpointName;

        }


        #region IDisposable
        ~ServiceProxyBase()
        {

            Dispose(false);

        }



     



        public void Dispose()
        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }



        private void Dispose(bool disposeManaged)
        {

            if (_disposed) return;

            if (disposeManaged)
            {

                lock (_sync)
                {

                    CloseChannel();

                    if (_channelFactory != null)
                    {

                        ((IDisposable)_channelFactory).Dispose();

                    }

                    _channel = null;

                    _channelFactory = null;

                }

            }

            _disposed = true;

        }



        #endregion



        protected T Channel
        {

            get
            {

                Initialize();



                return _channel;

            }

        }



        protected void CloseChannel()
        {

            if (_channel != null)
            {

                ((ICommunicationObject)_channel).Close();

            }

        }



        private void Initialize()
        {

            lock (_sync)
            {

                if (_channel != null) return;



                var factory = new ChannelFactory<T>(_endpointName);

                //var layout = new LayoutBehaviour();

                //factory.Endpoint.Behaviors.Add(layout);

                _channel = factory.CreateChannel();

            }

        }

    }
}