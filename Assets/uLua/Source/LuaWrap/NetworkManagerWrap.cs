using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class NetworkManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("OnInit", OnInit),
		new LuaMethod("AddEvent", AddEvent),
		new LuaMethod("Logout", Logout),
		new LuaMethod("SendConnect", SendConnect),
		new LuaMethod("SendMessage", SendMessage),
		new LuaMethod("IsConnectSuccess", IsConnectSuccess),
		new LuaMethod("GetErrorMsg", GetErrorMsg),
		new LuaMethod("New", _CreateNetworkManager),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNetworkManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "NetworkManager class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(NetworkManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "NetworkManager", typeof(NetworkManager), regs, fields, typeof(BaseLua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnInit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NetworkManager obj = LuaScriptMgr.GetUnityObject<NetworkManager>(L, 1);
		obj.OnInit();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		ByteBuffer arg1 = LuaScriptMgr.GetNetObject<ByteBuffer>(L, 2);
		NetworkManager.AddEvent(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Logout(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NetworkManager obj = LuaScriptMgr.GetUnityObject<NetworkManager>(L, 1);
		obj.Logout();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendConnect(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 1)
		{
			NetworkManager obj = LuaScriptMgr.GetUnityObject<NetworkManager>(L, 1);
			obj.SendConnect();
			return 0;
		}
		else if (count == 3)
		{
			NetworkManager obj = LuaScriptMgr.GetUnityObject<NetworkManager>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.SendConnect(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: NetworkManager.SendConnect");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NetworkManager obj = LuaScriptMgr.GetUnityObject<NetworkManager>(L, 1);
		ByteBuffer arg0 = LuaScriptMgr.GetNetObject<ByteBuffer>(L, 2);
		obj.SendMessage(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsConnectSuccess(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NetworkManager obj = LuaScriptMgr.GetUnityObject<NetworkManager>(L, 1);
		bool o = obj.IsConnectSuccess();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetErrorMsg(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NetworkManager obj = LuaScriptMgr.GetUnityObject<NetworkManager>(L, 1);
		string o = obj.GetErrorMsg();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetVarObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetVarObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

