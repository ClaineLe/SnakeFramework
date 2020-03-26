MainCityScreen = {

}

setmetatable(MainCityScreen, {__index = UIBaseScreen})

function MainCityScreen:OnLoadSuccess( )
	self:add_button("FunctionArea/btnGuild", self.OnClickGuild)
	self:add_button("FunctionArea/btnTask", self.OnClickTask)
	self:get_subscreen("SubScreen")
end

function MainCityScreen:OnRelease( )
end

function MainCityScreen:OnClickGuild( )
	print("MainCityScreen:OnClickGuild")
end
function MainCityScreen:OnClickTask( )
	self:RemoveListeners()
end