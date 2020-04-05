GuildPanel = {
	subPanel = nil,
}

setmetatable(GuildPanel, {__index = UIPanel})

function GuildPanel:OnCreatePanel( ) end
function GuildPanel:OnReleasePanel( ) end


function GuildPanel:OnInitPanel( )
	self:add_button("CreateGuild/btnClose", self.OnCloseClick)
	self:add_button("GuildInfo/btnClose", self.OnCloseClick)

	self:add_button("GuildInfo/FunctionGroup/btnFunc1", self.OnTaskClick)
	self.subPanel = self:get_subscreen("SubPanel")
end


function GuildPanel:OnCloseClick( )
	self:Close()
end

function GuildPanel:OnTaskClick( )
	event.ui:emit("XXXX",123,456,"7889")
	ui.open(UIConst.Task)
end