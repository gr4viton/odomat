function [dx,dy,dth] = step_sim_path( pathl, pathr, b, th0, t_step)
% calculates one step of the simulation with the time step t_step
dpath = (pathl + pathr) / 2;
dth = (pathr - pathl)/b;
th = th0 + dth;
dx = dpath * cos(th);
dy = dpath * sin(th);