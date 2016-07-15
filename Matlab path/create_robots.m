function [i_rob, rob] = create_robots(rob0,cislo_mereni,utc_offset_odom)

%% classic goings
x=34;
astr2 = x* repmat([10 10.000000001; 10.000000001 10],25,1); % almost_straight 
astr = x*repmat([10 10.000000001], 15,1); % almost_straight 
str = x*repmat([10 10],50,1); % straight 
tleft = repmat([-pi/2 pi/2]*rob0.b/2/rob0.aR ,1,1); %turn90
tleft8s = repmat([-pi/2/8 pi/2/8]*rob0.b/2/rob0.aR ,8,1); %turn90
tleftL8s = repmat([0 pi/2/8]*rob0.b/rob0.aR ,8,1); %turn90
tleftR8s = repmat([pi/2/8 0]*rob0.b/rob0.aL ,8,1); %turn90
tright = repmat([pi/2 -pi/2]*rob0.b/2/rob0.aR ,1,1) ; %turn90
cleft = x*repmat([10 12.2],10,1); %left100
rleft = x*repmat([4.2 10],10,1); %right100
cleft200 = x*repmat([10 2.1],10,1); %left100

%% create rob array from def rob0
% i_rob = 6;
% rob = repmat(rob0,1,i_rob);
% rob(1).th = pi/2;
% 
% rob(2).x = rob(2).x + 800;
% rob(2).y = rob(2).y + 100;
% rob(2).plot_period = 3;
% % rob(2).variance_visible = 0;
% 
% rob(3).x = rob(3).x - 50;
% rob(3).th = -pi;
% i_rob = 10;

%% ground truth
% ground_truth(rob0);

%% odolog 357
xx = 5;
i_rob = 4;
% i_rob = 1;
rob = repmat(rob0,1,i_rob);
% 
% %% 1
i = 1;
[rob(i).meas rob(i).utc ]= parse_meas(cislo_mereni);
rob(i).utc = rob(i).utc;

% rob(i).color1 = [0 0.5 1];
% rob(i).color2 = [0 0.7 0.7];
% rob(i).title = '- blue - original (Es=1, xUMB)';
% 
% rob(i).calc_eqn = 1;
% rob(i).digits_rob = 15;
% rob(i).plot_period = 10;
% 
% % 
% % sigmax = 0.034;
% % sigmay = 0.034;
% % sigmath = deg2rad(0.5);
% % % sigmax = 0.0728;
% % % sigmay = 0.15;
% % % sigmath = 0;
% % Q11 = sigmax^2;
% % Q22 = sigmay^2;
% % Q33 = sigmath^2;
% % Q = diag( [Q11,Q22,Q33] );
% %% 2
% i = i+1;
% rob(i) = rob(i-1);
% rob(i).color1 = [0 1 0];
% rob(i).color2 = [0 0.7 0];
% rob(i).title = '- green - (Es=0.9941, xUMB)';
% 
% Es = 0.9941;
% rob(i).rL = rob0.rL * Es;
% rob(i).rR = rob0.rR * Es;
% 
% %% 3
% i = i+1;
% rob(i) = rob(i-1);
% rob(i).color1 = [1 0 0];
% rob(i).color2 = [0.7 0.3 0];
% rob(i).title = '- red - (Es=1, UMB1)';
% 
% cB = 0.99987; cL = 0.99995; cR = 1.00005;
% rob(i).b = rob0.b * cB;
% rob(i).rR = rob0.rR * cR;
% rob(i).rL = rob0.rL * cL;

%% 4
% i = i+1;
% rob(i) = rob(i-1);
rob(i).color1 = [1 0 1];
rob(i).color2 = [0.7 0 0.7];
rob(i).title = '- pink - (Es=0.9941,UMB0.9441)';

Es = 0.9941;
cB = 0.99980; cL = 0.99995; cR =1.00005;
rob(i).b = rob0.b * cB;
rob(i).rR = rob0.rR * cR * Es;
rob(i).rL = rob0.rL * cL * Es;


% UMBmark tunning
% cL =0.9961643515;
% cR = 1.0038356485;
% cB = 0.9970168843;
% cL =0.9963362867;
% cR = 1.0036637133;
% cB = 0.9481099259
%% 
% cL =0.9886671284;
% cR = 1.0113328716;
% cB = 0.9481099259;


% rob(i).b = rob(i).b * cB;
% rob(i).rR = rob(i).rR * cR;
% rob(i).rL = rob(i).rL * cL;

% 
% i = i+1;
% rob(i) = rob(i-1);
% rob(i).color1 = [0.0 0.0 0.9];
% % UMBmark tunning
% cL =0.9961643515;
% cR = 1.0038356485;
% cB = 0.9970168843;
% % cL =0.9963362867;
% % cR = 1.0036637133;
% % cB = 0.9898161639;
% rob(i).b = rob0.b * cB;
% rob(i).rR = rob0.rR * cR;
% rob(i).rL = rob0.rL * cL;

% rob(i).cR = 2 / (Ed + 1);
% rob(i).cL = 2 / (1/Ed + 1);

% rob(i).x = rob(i-1).x + xx;
% rob(i).calc_eqn = 1;
% rob(i).digits_rob = 7;
% 
% i = i+1;
% rob(i).meas = rob(i-1).meas;
% rob(i).x = rob(i-1).x + xx;
% rob(i).calc_eqn = 2;
% rob(i).digits_rob = 7;

for i=1:i_rob
rob(i).aR = 1 / rob(i).TR *2*pi * rob(i).rR;
rob(i).aL = 1 / rob(i).TL *2*pi * rob(i).rL;
end

%% try straight probability
% 
% i_rob = 2;
% rob = repmat(rob0,1,i_rob);
% 
% rob(1).meas = [ astr; astr; astr; astr; astr; astr; cleft; ];
% rob(2).meas = [ str; str; str; str; str; str; cleft; ];
% 
% rob(1).plot_period = 25;
% rob(2).plot_period = 25;


%% circular robots
% i_rob = 3;
% rob = repmat(rob0,1,i_rob+1);
% R = 1;
% for i=1:(i_rob+1)
%     th = 2*pi*i/(i_rob) ;
%     rob(i).x = R*sin(th+pi/2);
%     rob(i).y = -R*cos(th+pi/2);
%     rob(i).th = th;
%     rob(i).meas = repmat(cleft,6,1);
% %     rob(i).meas = i/4*repmat(astr2,1,1);
%     plot_robot(rob(i));
%     rob(i).plot_period = 15;
% end


% rob(1).meas = [ astr; tleft; astr; tleft; astr; tleft; astr; astr; astr; tleft; astr; cleft; rleft; cleft; rleft; cleft; rleft; cleft; rleft; cleft; rleft; rleft; cleft; rleft; cleft; rleft; cleft; rleft; cleft; rleft;];
% rob(2).meas = [ cleft; rleft; cleft; rleft; cleft; rleft; rleft; cleft; rleft; cleft; rleft; cleft; rleft; cleft; rleft ];

% rob(1).meas = [ astr;  rleft; astr; tleft; ]%astr; tleft; astr; astr; astr; tleft; astr; cleft; rleft; cleft; ];
% rob(1).meas = [ astr; cleft200; cleft200; cleft200; cleft200; cleft200; cleft200; ];
% rob(2).meas = [ astr; cleft200; cleft200; cleft200; cleft200; cleft200; cleft200;  astr; ];
% rob(2).meas = [ cleft; rleft; astr; astr; astr;   ];
% rob(3).meas = [ cleft; rleft; cleft; rleft; cleft; rleft;  ];


% rob(2).meas = [astr];
