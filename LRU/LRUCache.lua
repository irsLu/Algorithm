LRUCache = {
	hashMap = {},
	limit = nil
}

Node = {
	pre = nil,
	value = nil,
	key = nil,
	nex = nil
}

local last = nil
local head = nil

function Node:new(key, value)
	local o = {}

	o.key = key
	o.value = value

	setmetatable(o, self)
	self.__index = function (t,k)
		local ret = Node[k]
		o[k] = ret
		return ret
	end

	return o
end

setmetatable(LRUCache.hashMap, {__mode = "kv"})

function LRUCache:init(_limit)
	self.limit = _limit
end


function LRUCache:get(key)
	local node = self.hashMap[key]
	if nil == node then
		return nil
	end

	self:refresh(node)
	return node.value
end

function  LRUCache:put(key, value)
	local node = self.hashMap[key]

	if nil == node then 
		if self:size() >= self.limit then

			local oldkey = self:remove(head)
			self.hashMap[oldkey] = nil
		end

		local node = Node:new(key, value)
		self:add(node)
		self.hashMap[key] = node
	else
		node.value = value
		refresh()
	end
end

function LRUCache:refresh(node)
	if last == node then return end

	self:remove(node)

	self:add(node)
end

function LRUCache:add(node)
	if last then
		last.nex = node
		node.pre = last
		node.nex = nil
	end

	last = node

	if head == nil then head = node end
end

function LRUCache:remove(node)
	if last == node then
		last = last.pre
	elseif head == node then 
		head = head.nex 
	else
		node.pre.nex = node.nex 
		node.nex.pre = node.pre
	end
	print("remove_"..node.key)
	return node.key
end

function LRUCache:size()
	local num = 0
	for k,v in pairs(self.hashMap) do
		if k and v then
			num = num + 1
		end
	end
	print("size_"..num)
	return num
end

local test = LRUCache
test:init(5)

test:put("a", 1)

test:put("b", 2)

test:put("c", 3)

test:put("d", 4)

test:put("e", 5)

test:put("v", 6)

test:get("b")

--collectgarbage("collect")

print(head.value)
print(last.value)

