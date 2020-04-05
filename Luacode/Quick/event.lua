local Dispatcher = require "Tools.EventDispatcher"

event = {
	ui = nil,
	sys = nil,
}

event.ui = Dispatcher()
event.sys = Dispatcher()