
MainCityPanel = {

}

setmetatable(MainCityPanel, {__index = UIPanel})

function MainCityPanel:OnLoadSuccess( )
	self:add_button("FunctionArea/btnGuild", self.OnClickGuild)
	self:add_button("FunctionArea/btnTask", self.OnClickTask)
	self:get_subscreen("SubScreen")
end

function MainCityPanel:OnRelease( )
end

function MainCityPanel:OnClickGuild( )
	local guildPanel = GameFacade.mUiMgr:OpenUI(UIConst.UIGuild)
end

function MainCityPanel:OnClickTask( )
	local taskPanel = GameFacade.mUiMgr:OpenUI(UIConst.UITask)
end
