TaskPanel = {

}

setmetatable(TaskPanel, {__index = UIPanel})


function TaskPanel:OnCreatePanel( )
	self.mPriority = UIPriority.PriorityLobbyForNewPlayerGuide
end

function TaskPanel:OnInitPanel( )
	self:add_button("btnClose", self.OnCloseClick)
end

function TaskPanel:OnReleasePanel( )
end

function TaskPanel:OnCloseClick( )
	self:Close()
end
