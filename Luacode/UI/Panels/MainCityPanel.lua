MainCityPanel = {

}

setmetatable(MainCityPanel, {__index = UIPanel})


function MainCityPanel:OnCreatePanel( ) end
function MainCityPanel:OnReleasePanel( ) end

function MainCityPanel:OnInitPanel( )
	self:add_button("FunctionArea/btnGuild", self.OnClickGuild)
	self:add_button("FunctionArea/btnTask", self.OnClickTask)
	self:get_subscreen("SubPanel")
end


function MainCityPanel:OnClickGuild( )
	local guildPanel = GameFacade.mUiMgr:OpenUI(UIConst.UIGuild)
end

function MainCityPanel:OnClickTask( )
	local taskPanel = GameFacade.mUiMgr:OpenUI(UIConst.UITask)
end
