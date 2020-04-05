GuildPanel = {
	subPanel = nil,
}

setmetatable(GuildPanel, {__index = UIPanel})

function GuildPanel:OnCreatePanel( ) end
function GuildPanel:OnReleasePanel( ) end


function GuildPanel:OnInitPanel( )
	self:add_button("CreateGuild/btnClose", self.OnCloseClick)
	self:add_button("GuildInfo/btnClose", self.OnCloseClick)
	self.subPanel = self:get_subscreen("SubPanel")
end


function GuildPanel:OnCloseClick( )
	self:Close()
end
