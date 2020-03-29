TaskPanel = {

}

setmetatable(TaskPanel, {__index = UIPanel})

function TaskPanel:OnLoadSuccess( )
	self:add_button("btnClose", self.OnCloseClick)
end

function TaskPanel:OnRelease( )
end

function TaskPanel:OnCloseClick( )
	self:OnClose()
end
