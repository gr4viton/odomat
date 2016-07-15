function plotGauss2dDemo()
% plotSurf
% approxeq
% gaussSampledemo
% plot2dgauss
% plotGauss2dDemo
% conf2mahal
clc;
mu = [1 0]'; % mean (must be row vector for mvnpdf)
S = [4 3; 3 4]; % covariance
figure(1); clf
plotSurf(mu, S, 1)
% Compute whitening transform:
[U,D] = eig(S); % U = eigenvectors, D= diagonal matrix of eigenvalues.
A = sqrt(inv(D))*U';
mu2 = A*mu;
S2 = A*S*A';
plotSurf(mu2, S2, 3)
%%%%%%%%%%%