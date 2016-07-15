function [robpos, robth] = update_robot(rob, dx, dy, dth)
% sends updated robot coordinates
robth = rob.th + dth;
robpos = [rob.pos(1) + dx, rob.pos(2) + dy]; 