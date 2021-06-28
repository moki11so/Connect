using System;
using System.Collections.Generic;

namespace MoSo.Connect.Service
{
	public interface IWawiPaymentService
	{
		bool HasPayments(string wawiOrderNumber);
		void CreatePayment(WawiPayment payment);
	}
}