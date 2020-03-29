GuildPanel = {

}

setmetatable(GuildPanel, {__index = UIPanel})

function GuildPanel:OnLoadSuccess( )
	self:add_button("CreateGuild/btnClose", self.OnCloseClick)
	self:add_button("GuildInfo/btnClose", self.OnCloseClick)
end

function GuildPanel:OnRelease( )
end


function GuildPanel:OnCloseClick( )
	self:OnClose()
end
