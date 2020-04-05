MainCityPanel = {

}

setmetatable(MainCityPanel, {__index = UIPanel})

function MainCityPanel:OnReleasePanel( ) end

function MainCityPanel:OnCreatePanel( ) 
	self.mAlwaysShow = true
end

function MainCityPanel:OnInitPanel( )
	self:add_button("FunctionArea/btnGuild", self.OnClickGuild)
	self:add_button("FunctionArea/btnTask", self.OnClickTask)
	self:get_subscreen("SubPanel")

	event.ui:on("XXXX", self.OnEvent)
end

function MainCityPanel:OnEvent( ... )
	print( ... )
end

function MainCityPanel:OnClickGuild( )
	local guildPanel = ui.open(UIConst.Guild)
end

function MainCityPanel:OnClickTask( )
	local taskPanel = ui.open(UIConst.Task)
end
