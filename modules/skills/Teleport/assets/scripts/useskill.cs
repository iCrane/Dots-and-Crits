function Teleport::useskill(%this,%user,%barslot)
{
%player=$players.getObject(%user);
if (isObject(%player.sprite))
{
if (%player.cancast&&!%barslot.skillstate)
{
%player.cancast=false;
%barslot.skillstate=1;//set to cooldown  //need to setup a function to display timer and remove cd
%player.skillanimtype=0;
Teleport.setskillbaricon(%barslot);
%schedulehandle_teleport=new SimObject()
{
schedulehandle="0";
};
$skillschedules.add(%schedulehandle_teleport);
%barslot.cdschedule=schedule(1000,0,"readyskillslot",%barslot);
Teleport.skill_teleport(%schedulehandle_teleport,%user,0);
}
}
}
