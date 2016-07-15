function [] = plot_variance(rob)
% draws the "robot"
% b = rob.b;
% r = rob.robot_radius;
% 
% th = rob.th;
% x0 = rob.x;
% y0 = rob.y;
% 
% 
% xrad = rob.P(1,1);
% yrad = rob.P(2,2);
% th = rob.P(3,3);

%   P(1,1)
%  _____
% /  S  \  P(2,2)
% \_____/

% ellipsedraw(xrad,yrad,x0,y0,0,'r');
% rectangle('Position',[posx-xrad, posy-yrad, 2*xrad, 2*yrad],...
%     'Curvature',[1,1]);
% Sigma{1} = rob.P(1:2,1:2);
% mu = [rob.x, rob.y];
plot2dgauss([rob.x, rob.y], rob.P(1:2,1:2), 'k');

% eigenvector
% [U,Lam]=eig(r.P);


% figure
% % imagesc(r.P);
% % plotmatrix(r.P);
% scatter(r.P(1,1),r.P(2,2),10,10);
% load seamount
% scatter(x,y,5,z)
% figure(1)