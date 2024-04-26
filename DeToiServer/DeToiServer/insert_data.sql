-- DELETE ALL!!!
Delete from [OrderServiceTypes];
Delete from [OrderService];
Delete from [OrderSkillsRequired];
Delete from [Orders];
Delete from [Services];

DELETE from [FreelancePaymentHistories];
DELETE from [FreelanceServiceTypes];

Delete from [SkillServiceTypes];
Delete from [FreelanceSkills];
Delete from [Skills];

DELETE from FreelanceCorrectQuestions;
delete from QuizQuestions;
delete from FreelanceQuizAnswers;
delete from FreelanceQuizQuestions;
delete from FreelanceQuizzes;
DELETE from FreelanceQuizResults;

Delete from [Addresses];
Delete from [Freelancers];
Delete from [Customers];
Delete from [Accounts];

Delete from [UIElementAdditionServiceRequirements];
Delete from [UIElementServiceRequirements];
Delete from [UIElementValidationTypes];
Delete from [UIElementServiceRequirementInputMethods];
Delete from [UIElementInputOptions];
Delete from [UIElementInputMethodTypes];

DELETE FROM [ServiceTypeStatuses];
DELETE FROM [ServiceTypes];
DELETE FROM [ServiceCategories];

INSERT INTO [ServiceCategories] ([Id], [Name], [Image], [Description], [ServiceClassName]) VALUES
('6f57d993-eb26-4b35-8c7d-7871a7fd624f', N'Học tập', 'services/hoctap/category.jpg', '', 'Learning'),
('d17ad87c-9f80-4f0e-bfd4-53138d900a6e', N'Đi chợ & Mua đồ hộ', 'services/dichomuadoho/category.jpg', '', 'Market'),
('8a21b21e-dc31-49c8-8b5b-84b69204dc3a', N'Giải trí', 'services/giaitri/category.jpg', '', 'Entertainment'),
('1b1a6ebd-2838-4b3d-a1f1-1818305df2d6', N'Vận Chuyển', 'services/vanchuyen/category.jpg', N'Dịch vụ Vận Chuyển giúp bạn chuyển đồ đạc, hàng hóa từ một địa điểm này đến địa điểm khác một cách thuận tiện và nhanh chóng', 'Moving'),
('a4676a9d-7dfb-4d23-8cb5-8e2678c4c611', N'Tư vấn & Hỏi đáp', 'services/tuvanhoidap/category.jpg', '', 'AskAway'); 

INSERT INTO [ServiceTypes] ([Id], [Name], [Description], [BasePrice], [Image], [AddressRequireOption], [ServiceCategoryId]) VALUES
('8b1f70d8-f765-4cff-8f70-e0b3407abcc2', N'Giải bài tập bậc đại học online', '', 0, 'services/hoctap/daihoctructiep.jpg', 'none', '6f57d993-eb26-4b35-8c7d-7871a7fd624f'),
('1fd6800d-d81f-4f73-945a-3fee4e076331', N'Giải bài tập bậc đại học gặp mặt trực tiếp', '', 0, 'services/hoctap/daihoconline.jpg', 'destination', '6f57d993-eb26-4b35-8c7d-7871a7fd624f'),
('8b8565e4-3629-45fa-8a02-2a3cc223189f', N'Giải bài tập THCS online', '', 0, 'services/hoctap/thcsonline.jpg', 'none', '6f57d993-eb26-4b35-8c7d-7871a7fd624f'),
('fdb466e5-a983-43d2-bc98-b2d890148907', N'Giải bài tập THCS gặp mặt trực tiếp', '', 0, 'services/hoctap/thcstructiep.jpg', 'destination', '6f57d993-eb26-4b35-8c7d-7871a7fd624f'),
('39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9', N'Giải bài tập THPT online', '', 0, 'services/hoctap/thptonline.jpg', 'none', '6f57d993-eb26-4b35-8c7d-7871a7fd624f'),
('eb765dba-ccb7-49f7-b43d-04ea15558ed4', N'Giải bài tập THPT gặp mặt trực tiếp', '', 0, 'services/hoctap/thpttructiep.jpg', 'destination', '6f57d993-eb26-4b35-8c7d-7871a7fd624f'),
('d44290b5-9fa0-42c0-b5cf-f2e9980721b8', N'Đi chợ truyền thống', '', 0, 'services/dichomuadoho/market.jpg', 'destination', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e'),
('1b1587c7-13d1-4606-a8b1-76cc1f05093a', N'Đi siêu thị / siêu thị mini', '', 0, 'services/dichomuadoho/supermarket.jpg', 'destination', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e'),
('f3d729cb-0a23-4369-aad5-2c2cb9e94ebf', N'Ngon và rẻ', '', 0, 'services/dichomuadoho/market.jpg', 'destination', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e'),
('95e967ae-68f4-4a40-8fc7-8073014430ed', N'Mua sắm hộ', '', 0, 'services/dichomuadoho/market.jpg', 'shipping', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e'),
('7f00c28b-87cd-47fe-a736-157118091675', N'Mua thuốc hộ', '', 0, 'services/dichomuadoho/market.jpg', 'shipping', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e'),
('25c9c567-5119-4140-a70b-5c3a1d1c3250', N'Chơi game chung theo giờ', '', 0, 'services/dichomuadoho/market.jpg', 'none', '8a21b21e-dc31-49c8-8b5b-84b69204dc3a'),
('6ee8adfe-323c-4648-aa94-37f6ece6083f', N'Chơi game chung theo số trận', '', 0, 'services/dichomuadoho/market.jpg', 'none', '8a21b21e-dc31-49c8-8b5b-84b69204dc3a'),
('cb217b7f-f921-4568-8d1c-bf891f6b38f0', N'Gửi đồ hộ', '', 0, 'services/vanchuyen/guidoho.jpg', 'shipping', '1b1a6ebd-2838-4b3d-a1f1-1818305df2d6'),
('96a7c6f2-73c2-4330-9629-c3441598ab94', N'Chuyển nhà trọn gói', '', 0, 'services/vanchuyen/chuyennhatrongoi.jpg', 'shipping', '1b1a6ebd-2838-4b3d-a1f1-1818305df2d6'),
('5a47d275-cd05-4521-9fe4-3aebbc8af90d', N'Chuyển phòng trọ trọn gói', '', 0, 'services/vanchuyen/chuyenphongtrotrongoi.jpg', 'shipping', '1b1a6ebd-2838-4b3d-a1f1-1818305df2d6'),
('20393b46-1f86-48ee-90e5-f8c20b90ff7a', N'Tư vấn tâm lý', '', 0, 'services/tuvanhoidap/tuvantamly.jpg', 'none', 'a4676a9d-7dfb-4d23-8cb5-8e2678c4c611'),
('c2523753-a16d-4839-910f-03b224019649', N'Giải đáp thắc mắc', '', 0, 'services/tuvanhoidap/giaidapthacmac.jpg', 'none', 'a4676a9d-7dfb-4d23-8cb5-8e2678c4c611'); 

INSERT INTO [ServiceTypeStatuses] ([ServiceTypeId], [ServiceStatusId]) VALUES
('8b1f70d8-f765-4cff-8f70-e0b3407abcc2', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('8b1f70d8-f765-4cff-8f70-e0b3407abcc2', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('8b1f70d8-f765-4cff-8f70-e0b3407abcc2', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('8b1f70d8-f765-4cff-8f70-e0b3407abcc2', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('8b1f70d8-f765-4cff-8f70-e0b3407abcc2', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('8b1f70d8-f765-4cff-8f70-e0b3407abcc2', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('1fd6800d-d81f-4f73-945a-3fee4e076331', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('1fd6800d-d81f-4f73-945a-3fee4e076331', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('1fd6800d-d81f-4f73-945a-3fee4e076331', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('1fd6800d-d81f-4f73-945a-3fee4e076331', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('1fd6800d-d81f-4f73-945a-3fee4e076331', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('1fd6800d-d81f-4f73-945a-3fee4e076331', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('1fd6800d-d81f-4f73-945a-3fee4e076331', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('8b8565e4-3629-45fa-8a02-2a3cc223189f', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('8b8565e4-3629-45fa-8a02-2a3cc223189f', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('8b8565e4-3629-45fa-8a02-2a3cc223189f', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('8b8565e4-3629-45fa-8a02-2a3cc223189f', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('8b8565e4-3629-45fa-8a02-2a3cc223189f', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('8b8565e4-3629-45fa-8a02-2a3cc223189f', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('fdb466e5-a983-43d2-bc98-b2d890148907', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('fdb466e5-a983-43d2-bc98-b2d890148907', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('fdb466e5-a983-43d2-bc98-b2d890148907', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('fdb466e5-a983-43d2-bc98-b2d890148907', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('fdb466e5-a983-43d2-bc98-b2d890148907', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('fdb466e5-a983-43d2-bc98-b2d890148907', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('fdb466e5-a983-43d2-bc98-b2d890148907', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('eb765dba-ccb7-49f7-b43d-04ea15558ed4', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('eb765dba-ccb7-49f7-b43d-04ea15558ed4', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('eb765dba-ccb7-49f7-b43d-04ea15558ed4', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('eb765dba-ccb7-49f7-b43d-04ea15558ed4', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('eb765dba-ccb7-49f7-b43d-04ea15558ed4', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('eb765dba-ccb7-49f7-b43d-04ea15558ed4', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('eb765dba-ccb7-49f7-b43d-04ea15558ed4', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('d44290b5-9fa0-42c0-b5cf-f2e9980721b8', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('d44290b5-9fa0-42c0-b5cf-f2e9980721b8', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('d44290b5-9fa0-42c0-b5cf-f2e9980721b8', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('d44290b5-9fa0-42c0-b5cf-f2e9980721b8', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('d44290b5-9fa0-42c0-b5cf-f2e9980721b8', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('d44290b5-9fa0-42c0-b5cf-f2e9980721b8', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('d44290b5-9fa0-42c0-b5cf-f2e9980721b8', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('1b1587c7-13d1-4606-a8b1-76cc1f05093a', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('1b1587c7-13d1-4606-a8b1-76cc1f05093a', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('1b1587c7-13d1-4606-a8b1-76cc1f05093a', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('1b1587c7-13d1-4606-a8b1-76cc1f05093a', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('1b1587c7-13d1-4606-a8b1-76cc1f05093a', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('1b1587c7-13d1-4606-a8b1-76cc1f05093a', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('1b1587c7-13d1-4606-a8b1-76cc1f05093a', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('f3d729cb-0a23-4369-aad5-2c2cb9e94ebf', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('f3d729cb-0a23-4369-aad5-2c2cb9e94ebf', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('f3d729cb-0a23-4369-aad5-2c2cb9e94ebf', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('f3d729cb-0a23-4369-aad5-2c2cb9e94ebf', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('f3d729cb-0a23-4369-aad5-2c2cb9e94ebf', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('f3d729cb-0a23-4369-aad5-2c2cb9e94ebf', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('f3d729cb-0a23-4369-aad5-2c2cb9e94ebf', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('95e967ae-68f4-4a40-8fc7-8073014430ed', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('95e967ae-68f4-4a40-8fc7-8073014430ed', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('95e967ae-68f4-4a40-8fc7-8073014430ed', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('95e967ae-68f4-4a40-8fc7-8073014430ed', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('95e967ae-68f4-4a40-8fc7-8073014430ed', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('95e967ae-68f4-4a40-8fc7-8073014430ed', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('95e967ae-68f4-4a40-8fc7-8073014430ed', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('7f00c28b-87cd-47fe-a736-157118091675', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('7f00c28b-87cd-47fe-a736-157118091675', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('7f00c28b-87cd-47fe-a736-157118091675', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('7f00c28b-87cd-47fe-a736-157118091675', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('7f00c28b-87cd-47fe-a736-157118091675', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('7f00c28b-87cd-47fe-a736-157118091675', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('7f00c28b-87cd-47fe-a736-157118091675', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('25c9c567-5119-4140-a70b-5c3a1d1c3250', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('25c9c567-5119-4140-a70b-5c3a1d1c3250', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('25c9c567-5119-4140-a70b-5c3a1d1c3250', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('25c9c567-5119-4140-a70b-5c3a1d1c3250', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('25c9c567-5119-4140-a70b-5c3a1d1c3250', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('25c9c567-5119-4140-a70b-5c3a1d1c3250', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('6ee8adfe-323c-4648-aa94-37f6ece6083f', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('6ee8adfe-323c-4648-aa94-37f6ece6083f', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('6ee8adfe-323c-4648-aa94-37f6ece6083f', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('6ee8adfe-323c-4648-aa94-37f6ece6083f', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('6ee8adfe-323c-4648-aa94-37f6ece6083f', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('6ee8adfe-323c-4648-aa94-37f6ece6083f', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('cb217b7f-f921-4568-8d1c-bf891f6b38f0', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('cb217b7f-f921-4568-8d1c-bf891f6b38f0', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('cb217b7f-f921-4568-8d1c-bf891f6b38f0', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('cb217b7f-f921-4568-8d1c-bf891f6b38f0', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('cb217b7f-f921-4568-8d1c-bf891f6b38f0', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('cb217b7f-f921-4568-8d1c-bf891f6b38f0', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('cb217b7f-f921-4568-8d1c-bf891f6b38f0', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('96a7c6f2-73c2-4330-9629-c3441598ab94', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('96a7c6f2-73c2-4330-9629-c3441598ab94', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('96a7c6f2-73c2-4330-9629-c3441598ab94', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('96a7c6f2-73c2-4330-9629-c3441598ab94', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('96a7c6f2-73c2-4330-9629-c3441598ab94', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('96a7c6f2-73c2-4330-9629-c3441598ab94', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('96a7c6f2-73c2-4330-9629-c3441598ab94', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('5a47d275-cd05-4521-9fe4-3aebbc8af90d', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('5a47d275-cd05-4521-9fe4-3aebbc8af90d', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('5a47d275-cd05-4521-9fe4-3aebbc8af90d', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('5a47d275-cd05-4521-9fe4-3aebbc8af90d', '0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2'),
('5a47d275-cd05-4521-9fe4-3aebbc8af90d', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('5a47d275-cd05-4521-9fe4-3aebbc8af90d', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('5a47d275-cd05-4521-9fe4-3aebbc8af90d', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('20393b46-1f86-48ee-90e5-f8c20b90ff7a', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('20393b46-1f86-48ee-90e5-f8c20b90ff7a', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('20393b46-1f86-48ee-90e5-f8c20b90ff7a', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('20393b46-1f86-48ee-90e5-f8c20b90ff7a', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('20393b46-1f86-48ee-90e5-f8c20b90ff7a', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('20393b46-1f86-48ee-90e5-f8c20b90ff7a', '0774e101-f1a3-4186-af1e-af95a26e9ead'),
('c2523753-a16d-4839-910f-03b224019649', 'a888efc3-1d7b-445a-b38c-758737b67bad'),
('c2523753-a16d-4839-910f-03b224019649', 'a53e9887-2186-4ff8-a009-f7706c800b52'),
('c2523753-a16d-4839-910f-03b224019649', '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('c2523753-a16d-4839-910f-03b224019649', '3f98b502-7245-4e86-b7b4-7db05357a1f8'),
('c2523753-a16d-4839-910f-03b224019649', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('c2523753-a16d-4839-910f-03b224019649', '0774e101-f1a3-4186-af1e-af95a26e9ead');

INSERT INTO [Accounts] ([Id], [Email], [FullName], [DateOfBirth], [Gender], [CountryCode], [Phone], [CombinedPhone], [Role], [Avatar], [RefreshToken], [LoginToken], [LoginTokenExpires], [TokenCreated], [TokenExpires], [IsActive], [IsVerified]) VALUES
('d466c2a7-44e7-457d-a1ff-40646c4cf2c4', null, N'Hoàng Quỳnh Nhi', '1978-01-13', 'Female', '+84', '123456789', '+84123456789', 'Admin', 'customer_avt/user-avt%20(1).png', 'string', 'default', '2024-04-13T20:27:27.285403', '2024-04-13 20:17:27.285403', '2024-04-13 20:27:27.285403', 1, 1),
('2695c848-8144-4a94-8d4d-763c5e768233', null, N'Ngô Vũ Lan Ngọc', '2006-02-17', 'Female', '+84', '337839146', '+84337839146', 'Freelancer', 'customer_avt/user-avt%20(2).png', 'string', 'default', '2024-04-13T20:27:27.242395', '2024-04-13 20:17:27.242395', '2024-04-13 20:27:27.242395', 1, 1),
('a7a76113-1a12-46c5-abec-01b0cccd1dde', null, N'Dương Hồ Gia Uy', '1989-06-30', 'Male', '+84', '914510313', '+84914510313', 'Freelancer', 'customer_avt/user-avt%20(3).png', 'string', 'default', '2024-04-13T20:27:27.283402', '2024-04-13 20:17:27.283402', '2024-04-13 20:27:27.283402', 1, 1),
('95be2640-b5ec-416b-9153-09cbc7ec60f8', null, N'Lê Nhất Duy', '2002-04-09', 'Male', '+84', '373344123', '+84373344123', 'Admin', 'customer_avt/user-avt%20(3).png', 'string', 'default', '2024-05-07T17:25:40.825617', '2024-04-07 17:15:40.825617', '2024-05-07 17:25:40.825617', 1, 1),
('9a9ffdf1-0cc7-4efc-80b7-d34524010af5', null, N'Trương Xuân Hiền', '1998-02-11', 'Male', '+84', '795202798', '+84795202798', 'Customer', 'customer_avt/user-avt%20(3).png', 'string', 'default', '2024-04-13T20:27:27.323945', '2024-04-13 20:17:27.323945', '2024-04-13 20:27:27.323945', 1, 1); 

INSERT INTO [Freelancers] ([Id], [AccountId], [Rating], [TotalReviewCount], [Balance], [SystemBalance], [OrderCount], [LoveCount], [PositiveReviewCount], [IdentityNumber], [IsTeam], [Description], [TeamMemberCount]) VALUES
('89291984-3389-4fe8-8f58-9ec54f17b5bc', 'd466c2a7-44e7-457d-a1ff-40646c4cf2c4', 0, 0, 'mvmeUKFmBhX0hRIhHsbkrQ==', 'LMc/hborrsvOrM4sz6SVSA==', 0, 0, 0, '051200000011', 0, 'Beyond its particularly tree whom local tend. Artist truth trouble behavior style. Ability management test during foot that course nothing. Sound central myself before year. Your majority feeling fact by four two. White owner onto knowledge other.', 1),
('75968ca3-4984-41ac-bbcd-dc899e4215b6', '2695c848-8144-4a94-8d4d-763c5e768233', 0, 0, 'GGSMJXGsxueAw2IPd9mlOQ==', 'a201S3x4D6GyLyKzRPu2dw==', 0, 0, 0, '051200000012', 1, 'Party prevent live. Quickly candidate change although. Together type music hospital. Every speech support time operation wear often.', 5),
('e7784f3c-b89c-4d7f-a2b6-4cc66e917535', 'a7a76113-1a12-46c5-abec-01b0cccd1dde', 0, 0, 'E3hg7DYxXUJQvPi7V2ctpw==', '29psh5iNvVDThfvYDMHNIw==', 0, 0, 0, '051200000013', 1, 'Picture suddenly drug rule bring determine some forward. Beyond chair recently and. Plant view own available buy country store. Hospital have wonder already. Create wife responsibility. Decision song view age international big employee.', 3); 

INSERT INTO [Customers] ([Id], [AccountId], [CustomerRank], [MemberPoint]) VALUES
('badc9643-88e7-4f4d-997a-c31229ac9816', '9a9ffdf1-0cc7-4efc-80b7-d34524010af5', 'Unranked', 0); 

INSERT INTO [Addresses] ([Id], [Lat], [Lon], [CustomerAccountId], [FreelanceAccountId], [AddressLine], [Ward], [District], [Province], [Country]) VALUES
('27e60c9b-36ff-45cb-a0cf-553f0e502d6d', 10.537583154037922, 106.9838823422087, null, '89291984-3389-4fe8-8f58-9ec54f17b5bc', N'227 Nguyễn Văn Cừ, phường 4, Quận 5, Thành phố Hồ Chí Minh, Việt Nam', N'Phường 17', N'Quận Gò Vấp', N'Thành phố Hồ Chí Minh', N'Việt Nam'),
('83e38f4d-707d-4f01-bd47-df02eb095dbc', 10.67563583577821, 106.73320667367813, null, '75968ca3-4984-41ac-bbcd-dc899e4215b6', N'227 Nguyễn Văn Cừ, phường 4, Quận 5, Thành phố Hồ Chí Minh, Việt Nam', N'Phường 6', N'Quận 4', N'Thành phố Hồ Chí Minh', N'Việt Nam'),
('505fe2c8-403b-499a-8925-f7ce984b23c6', 10.666776428111056, 106.95662047595832, null, 'e7784f3c-b89c-4d7f-a2b6-4cc66e917535', N'227 Nguyễn Văn Cừ, phường 4, Quận 5, Thành phố Hồ Chí Minh, Việt Nam', N'Phường 15', N'Quận Gò Vấp', N'Thành phố Hồ Chí Minh', N'Việt Nam'),
('9dd88994-8e5d-445e-83cb-9ff64014a833', 10.578521824021678, 106.61148366903966, 'badc9643-88e7-4f4d-997a-c31229ac9816', null, N'227 Nguyễn Văn Cừ, phường 4, Quận 5, Thành phố Hồ Chí Minh, Việt Nam', N'Phường 7', N'Quận 5', N'Thành phố Hồ Chí Minh', N'Việt Nam'); 

INSERT INTO [Skills] ([Id], [Name], [Description]) VALUES
('d4c95511-492f-46aa-8326-84299acbe8fd', N'Vận chuyển hàng hóa', N'Xếp dỡ hàng hóa một cách an toàn và chuyên nghiệp'),
('510acfa4-eddb-4d08-b4ce-30ebf132922f', N'Quản lý lộ trình vận chuyển', N'Lập kế hoạch và điều chỉnh lộ trình vận chuyển hiệu quả'),
('28c41f96-ad80-457f-b59b-e948d1bd9135', N'Xử lý hàng hóa nhạy cảm', N'Chăm sóc và vận chuyển hàng hóa nhạy cảm một cách cẩn thận và đúng cách'),
('92fd24e8-abeb-45d3-a33c-02d24224b78d', N'Sử dụng các phương tiện vận chuyển đa dạng', N'Sử dụng xe tải, container và các phương tiện vận tải khác để vận chuyển hàng hóa một cách linh hoạt'),
('e7978b8d-a546-4133-a576-778f34985d06', N'Đóng gói hàng hóa chuyên nghiệp', N'Đóng gói hàng hóa bằng cách an toàn và chuyên nghiệp để đảm bảo an toàn trong quá trình vận chuyển'),
('d9b6ce05-94a3-4781-976d-707579d6fe5f', N'Giao hàng nhanh', N'Giao hàng nhanh chóng và chính xác đến địa chỉ chỉ định'),
('657fabfe-88db-46b4-ba2c-947f36b0ea45', N'Quản lý lịch trình giao hàng', N'Quản lý lịch trình giao hàng để đảm bảo giao hàng đúng thời hạn'),
('db42a4fc-a790-4706-bd0b-c263dbbc2522', N'Sử dụng phương tiện giao hàng nhỏ', N'Sử dụng xe máy, xe đạp hoặc phương tiện giao hàng nhỏ khác để giao hàng một cách nhanh chóng và linh hoạt'),
('562bb844-3fe4-486c-94a6-28876cdb287d', N'Xử lý hàng hóa đặc biệt', N'Xử lý và vận chuyển hàng hóa đặc biệt một cách chuyên nghiệp và cẩn thận'),
('126d9bee-996a-4880-b54e-a2ee84b5e822', N'Giao hàng theo yêu cầu', N'Giao hàng dựa trên yêu cầu cụ thể của khách hàng'),
('44c2a6e0-9437-4bee-b150-ffe0dc1b1c37', N'Chăm sóc người già', N'Cung cấp chăm sóc toàn diện cho người già trong gia đình'),
('049657d4-138c-4d0b-8d56-245e7f0a841d', N'Chăm sóc trẻ em', N'Đảm bảo sự an toàn và sự phát triển của trẻ em trong môi trường gia đình'),
('a9b4b60a-999d-463e-9d75-5ba249c3c91f', N'Xây dựng mối quan hệ với trẻ em', N'Xây dựng mối quan hệ tốt đẹp và trách nhiệm với trẻ em để tạo ra một môi trường hòa thuận và an toàn'),
('8837d38a-d219-40f5-9bc7-b439e69d17d2', N'Giáo dục về dinh dưỡng', N'Cung cấp kiến thức và hướng dẫn về dinh dưỡng cho trẻ em để hỗ trợ sự phát triển của họ'),
('b6f8ae11-db74-4c55-a9d7-f8904d4d5825', N'Tạo ra hoạt động giáo dục', N'Phát triển và tổ chức các hoạt động giáo dục thú vị và phù hợp với lứa tuổi của trẻ em'),
('59a05b2f-2857-49e0-a5dc-7e1746480dce', N'Lập danh sách mua sắm', N'Tạo danh sách mua sắm chi tiết và hiệu quả để tiết kiệm thời gian và tiền bạc'),
('e9d1a4d9-053f-4a60-a67e-3d59a11feeeb', N'Tư vấn lựa chọn sản phẩm', N'Tư vấn và hướng dẫn khách hàng trong việc lựa chọn sản phẩm phù hợp với nhu cầu và ngân sách của họ'),
('3eda0312-2f58-4f02-852d-bec6e4bc344b', N'Quản lý ngân sách mua sắm', N'Quản lý ngân sách mua sắm của khách hàng để đảm bảo mua sắm hiệu quả và không lãng phí'),
('d2fa3f68-6d70-4707-adda-0268312c25ee', N'Xử lý việc đổi trả hàng', N'Hỗ trợ khách hàng trong việc đổi trả hàng hoặc xử lý các vấn đề liên quan đến sản phẩm sau khi mua'),
('34698e8c-7ba7-4f52-851b-e2bf6c10426b', N'Kiểm tra sản phẩm', N'Kiểm tra sản phẩm để đảm bảo chất lượng và đầy đủ các thành phần trước khi mua'),
('7a5066e5-c755-4f49-9afa-0813626afb04', N'Xếp dỡ đồ đạc một cách chuyên nghiệp', N'Thực hiện việc xếp dỡ các đồ đạc như hành lý cá nhân và đồ dùng gia đình một cách chuyên nghiệp và an toàn'),
('fc77b33f-5f6e-4495-9837-14d8a049882d', N'Đóng gói hàng hóa cá nhân', N'Thực hiện việc đóng gói hàng hóa cá nhân như hành lý cá nhân và các vật phẩm cá nhân một cách cẩn thận và chuyên nghiệp'),
('8953f6d9-1e51-4907-b8ee-44cb5b4787d0', N'Quản lý kho hàng', N'Thực hiện việc quản lý và tổ chức kho hàng cho đồ đạc cá nhân một cách hiệu quả và chuyên nghiệp'),
('43bcbdaf-3cd6-44e4-add3-aec51dcf2c7d', N'Đóng gói và vận chuyển hàng hóa quốc tế', N'Thực hiện việc đóng gói và vận chuyển hàng hóa cá nhân qua các biên giới quốc tế một cách chuyên nghiệp và an toàn'),
('919b1e17-6392-42e7-93da-8ebb9b7b5381', N'Phân loại sản phẩm', N'Sắp xếp và phân loại sản phẩm một cách hiệu quả khi mua sắm tại các cửa hàng và siêu thị'),
('9932d1a2-1ad1-414a-9b75-64efbfc16183', N'Đàm phán giá cả', N'Kỹ năng đàm phán giá cả với người bán hàng để đảm bảo bạn có được giá ưu đãi nhất cho sản phẩm'),
('ae58cea3-240a-4ae1-969d-bd79a3ae812d', N'Tìm kiếm sản phẩm phù hợp', N'Nắm bắt nhu cầu và tìm kiếm các sản phẩm phù hợp nhất với yêu cầu của khách hàng'),
('a632afda-89b8-46eb-9077-360263230ac3', N'Kiểm tra chất lượng sản phẩm', N'Kiểm tra và đánh giá chất lượng của sản phẩm để đảm bảo bạn mua được hàng chất lượng nhất'),
('850d7b5d-5176-4c42-b2e5-c4c7d5870dce', N'Hiểu biết về giá cả và thị trường', N'Có kiến thức vững về giá cả và thị trường để có thể chọn lựa và mua sắm một cách thông minh'),
('b344f38a-e727-4ee9-8788-fe2b86930ae1', N'Chuẩn bị thực đơn đa dạng', N'Tạo ra thực đơn đa dạng và phong phú phục vụ nhu cầu ẩm thực của khách hàng'),
('cf707aab-5949-4a44-9312-e65ef934f088', N'Kỹ năng nấu ăn chuyên nghiệp', N'Sử dụng kỹ thuật nấu ăn chuyên nghiệp để tạo ra các món ăn ngon miệng và hấp dẫn'),
('54fbabe9-2b70-430f-bb47-da0ef1bf7ed9', N'Quản lý thời gian và nguyên liệu', N'Quản lý thời gian và nguyên liệu một cách hiệu quả để chuẩn bị và nấu các bữa ăn đúng thời hạn và chất lượng'),
('1018f7d5-d4ef-47a1-873d-085588426c72', N'Sáng tạo trong việc nấu ăn', N'Phát triển và áp dụng ý tưởng sáng tạo để tạo ra các món ăn mới và độc đáo'),
('536af6c4-fc9a-4fd5-89bb-cb592ed316af', N'Kỹ năng trình bày món ăn', N'Biến các món ăn trở nên hấp dẫn và bắt mắt thông qua kỹ năng trình bày món ăn sáng tạo'),
('11b3ca41-d04f-43b4-8f2b-a7dec67d9c61', N'Phân loại và sắp xếp quần áo', N'Hiểu biết về cách phân loại và sắp xếp quần áo một cách hiệu quả để tiện cho quá trình giặt ủi'),
('b07a9fc1-c869-4e35-adbe-b2e2627eed68', N'Xử lý quần áo nhạy cảm', N'Xử lý và giặt ủi quần áo có chất liệu nhạy cảm một cách cẩn thận và chuyên nghiệp'),
('0040bf7b-b8d9-46a2-b0d1-54d5e3a6aa76', N'Sử dụng máy giặt và máy sấy hiệu quả', N'Hiểu biết và sử dụng các thiết bị giặt ủi hiện đại một cách hiệu quả và tiết kiệm thời gian'),
('0e3c1e2b-f67e-4581-90c6-c9190c33f31f', N'Biết cách ủi quần áo một cách chuyên nghiệp', N'Hiểu biết về kỹ thuật và phương pháp ủi quần áo một cách chuyên nghiệp và linh hoạt'),
('b5a7fe43-e952-442a-a15a-8e8d89367462', N'Xử lý vết bẩn cứng đầu', N'Xử lý và loại bỏ các vết bẩn cứng đầu trên quần áo một cách hiệu quả và an toàn'),
('6666ca1d-2d5d-4764-b1bc-ad3fd3740058', N'Kiểm tra và chẩn đoán sự cố máy lạnh', N'Thực hiện kiểm tra kỹ thuật và chẩn đoán sự cố của máy lạnh để xác định nguyên nhân gây ra vấn đề'),
('2ef9de7c-98e7-4cf9-9258-ad1ae383a55e', N'Tháo lắp và lắp đặt máy lạnh', N'Thực hiện tháo lắp và lắp đặt máy lạnh một cách chuyên nghiệp và an toàn'),
('44adce9b-bbf2-4838-99bb-070ab14d3919', N'Bảo dưỡng định kỳ máy lạnh', N'Thực hiện bảo dưỡng định kỳ để đảm bảo máy lạnh hoạt động ổn định và hiệu quả'),
('0c5d44bc-db1c-4848-8d41-6788a7cfd0c5', N'Sửa chữa và thay thế linh kiện máy lạnh', N'Thực hiện sửa chữa và thay thế linh kiện máy lạnh hỏng hóc để khôi phục hoạt động của máy'),
('9491bccd-37b3-4796-a25d-be30a08c3541', N'Kiểm tra hiệu suất làm việc của máy lạnh', N'Đánh giá và kiểm tra hiệu suất làm việc của máy lạnh để đảm bảo hoạt động hiệu quả và tiết kiệm năng lượng'),
('c300ad2d-661e-4c0c-bd81-14e95c2d48a8', N'Phát hiện và sửa chữa rò rỉ', N'Phát hiện và khắc phục các vấn đề liên quan đến rò rỉ trong hệ thống ống nước'),
('423d0985-2f02-4e2a-bf23-1a37fcc3e4be', N'Thay thế ống nước hỏng', N'Tháo dỡ và thay thế các ống nước bị hỏng bằng các vật liệu chất lượng cao'),
('e9061193-6885-4e80-8539-24edabba06a3', N'Kiểm tra và bảo dưỡng hệ thống ống nước', N'Kiểm tra và thực hiện bảo dưỡng định kỳ cho hệ thống ống nước để đảm bảo hoạt động ổn định'),
('a825708a-a9e0-405e-86ae-2ac123a109ec', N'Sửa chữa vòi sen và bồn cầu', N'Sửa chữa và bảo dưỡng các vòi sen và bồn cầu để đảm bảo hoạt động hiệu quả'),
('9a9c5c0d-66b8-477d-a64d-c3d951848b29', N'Lắp đặt hệ thống ống nước mới', N'Lắp đặt hệ thống ống nước mới hoặc mở rộng hệ thống hiện có theo yêu cầu của khách hàng'),
('6615fcb9-deb5-4c89-9f75-b3f1cb77e477', N'Sửa chữa sàn gỗ', N'Chuyên sửa chữa và bảo dưỡng sàn gỗ một cách chuyên nghiệp và hiệu quả'),
('2b1e2526-ad8d-458f-84e9-48268d3a8bc6', N'Làm mới sàn gạch', N'Tạo ra sự mới mẻ và đẹp mắt cho sàn gạch bằng các phương pháp làm mới chuyên nghiệp'),
('4eea13e9-ee0a-4cd3-aa06-674eee41ba15', N'Bảo dưỡng sàn đá', N'Bảo dưỡng và làm sạch sàn đá để giữ cho nó luôn bền đẹp và bền vững'),
('3cde8b05-8857-4095-ae34-2388546c5b76', N'Sửa chữa sàn nhựa', N'Thực hiện các công việc sửa chữa và bảo dưỡng cho sàn nhựa để tăng tuổi thọ và độ bền của nó'),
('4c64db45-bdfe-4931-b9c8-305f30b1cc50', N'Làm mới sàn gỗ', N'Tạo ra sự mới mẻ và đẹp mắt cho sàn gỗ bằng các phương pháp làm mới chuyên nghiệp'),
('18305470-b98f-4c23-9ca4-86e6c7dbeac3', N'Dọn dẹp phòng khách', N'Dọn dẹp và sắp xếp lại không gian phòng khách của căn nhà một cách sạch sẽ và gọn gàng'),
('486b0bb3-5ad8-46f8-b299-3e79a9f0009a', N'Lau chùi bếp', N'Lau sạch bếp và các bề mặt liên quan để đảm bảo sự sạch sẽ và an toàn trong quá trình nấu nướng'),
('2c6a5f4e-ecab-4fe6-9035-bb33dc270708', N'Dọn dẹp phòng ngủ', N'Dọn dẹp và sắp xếp lại không gian phòng ngủ để tạo cảm giác thoải mái và thư giãn'),
('09630a6b-1cef-4a43-9755-ca42ec41d6c9', N'Lau dọn nhà tắm', N'Lau sạch và vệ sinh nhà tắm để đảm bảo vệ sinh cá nhân và sự thoải mái khi sử dụng'),
('cd06292a-e708-4c38-89f0-716041b77623', N'Dọn dẹp sân vườn', N'Dọn dẹp và bảo quản sân vườn để tạo một không gian ngoại thất sạch sẽ và thú vị'),
('0d394998-765f-45c5-ad29-c83aca9aed63', N'Lau chùi sàn nhà', N'Làm sạch và lau chùi các loại sàn nhà một cách kỹ lưỡng và hiệu quả'),
('9a9ef12b-04bd-4767-8bd7-4542c324ceda', N'Vệ sinh bề mặt', N'Sử dụng các phương pháp vệ sinh chuyên nghiệp để làm sạch bề mặt của căn nhà'),
('ec7c0211-b574-494f-b3bf-0425dfa9f8a8', N'Đánh bóng sàn nhà', N'Sử dụng các kỹ thuật đánh bóng chuyên nghiệp để làm cho sàn nhà trở nên sáng bóng'),
('42634124-88ef-4bb5-a40c-d7202c8289df', N'Vệ sinh nội thất', N'Lau chùi và vệ sinh các bề mặt nội thất như bàn ghế, kệ sách và đồ nội thất khác'),
('af4ff758-c07f-4d08-8a58-78af1dc0ca1c', N'Sơn phủ bề mặt', N'Sử dụng kỹ thuật sơn phủ chuyên nghiệp để làm mới và bảo vệ các bề mặt cần thiết'),
('7c244170-3402-41d8-8101-e162192e66c9', N'Quản lý lịch trình dọn dẹp', N'Lập kế hoạch và quản lý lịch trình dọn dẹp văn phòng hiệu quả'),
('9b5474fc-710e-4c94-943f-5bb84d075eb7', N'Xử lý và tái chế rác thải văn phòng', N'Xử lý và tái chế rác thải văn phòng một cách bền vững và hiệu quả'),
('66ba19f3-eb18-48e3-a95e-92e2146f886e', N'Sử dụng thiết bị dọn dẹp hiện đại', N'Sử dụng và vận hành các thiết bị dọn dẹp hiện đại để tăng hiệu suất và chất lượng dọn dẹp'),
('e5576d0a-1a33-4f62-bbe2-e870b29bdd71', N'Bố trí không gian văn phòng hợp lý', N'Bố trí không gian văn phòng một cách hợp lý để tối ưu hóa không gian làm việc'),
('56a8aa43-eb9a-4fd2-bf4f-3508a5e83c95', N'Xử lý và bảo quản tài liệu văn phòng', N'Xử lý và bảo quản tài liệu văn phòng một cách cẩn thận và tổ chức'),
('36fdb857-9e01-4c1c-b42c-ad9ff4f180a2', N'Làm sạch cửa sổ cẩn thận', N'Thực hiện việc làm sạch cửa sổ một cách cẩn thận và kỹ lưỡng để loại bỏ mọi vết bẩn và bụi bẩn'),
('a5d0a653-403d-4895-87e5-94cfafa8c974', N'Làm sạch kính trong suốt', N'Đảm bảo việc làm sạch kính một cách hoàn hảo để giữ cho cửa sổ luôn trong suốt'),
('5faa940a-9183-4885-907d-8f344f65a150', N'Lau chùi khung cửa chính xác', N'Thực hiện việc lau chùi khung cửa một cách chính xác và cẩn thận để đảm bảo sự sạch sẽ và bền bỉ'),
('dd04e3ae-8117-4540-ae3a-78e737ba351c', N'Sử dụng sản phẩm làm sạch chuyên nghiệp', N'Sử dụng các sản phẩm làm sạch chuyên nghiệp và hiệu quả để đạt được kết quả tốt nhất khi làm sạch cửa sổ'),
('6feffc0d-41ba-4e09-bbd8-2653f62dfffe', N'Xử lý các vết bẩn cứng đầu', N'Xử lý các vết bẩn khó chịu và cứng đầu trên cửa sổ một cách hiệu quả và nhanh chóng'),
('502d31b8-d89b-4946-a11d-14fbdb3909b4', N'Sử dụng thiết bị làm sạch chuyên nghiệp', N'Sử dụng các thiết bị và hóa chất làm sạch chuyên nghiệp để đảm bảo hiệu quả cao trong việc vệ sinh thảm văn phòng'),
('4b5bdfb7-5747-4d13-976a-c75a04ed0cbd', N'Thực hiện phương pháp làm sạch đa dạng', N'Áp dụng nhiều phương pháp làm sạch khác nhau tùy thuộc vào loại thảm và mức độ bẩn để đạt được kết quả tối ưu'),
('901b1065-716e-4551-aaa7-10022e81a8bb', N'Kiểm tra và loại bỏ vi khuẩn', N'Kiểm tra và áp dụng các biện pháp để loại bỏ vi khuẩn và vi sinh vật gây hại khác trong thảm văn phòng'),
('ed55b369-3f91-4b95-9ee6-36fdbba84550', N'Bảo dưỡng thảm vệ sinh định kỳ', N'Thực hiện các biện pháp bảo dưỡng định kỳ để giữ cho thảm văn phòng luôn sạch và tránh tình trạng bám bụi, bẩn'),
('dd3ed168-3f96-4c74-b508-94d620804779', N'Kiểm tra và làm sạch lọc khí', N'Kiểm tra và làm sạch lọc khí của máy lạnh để cải thiện chất lượng không khí'),
('bf45b2db-80ef-4fe4-80ec-e20f9b143bd4', N'Kiểm tra và nạp gas làm lạnh', N'Kiểm tra và nạp gas làm lạnh cho hệ thống máy lạnh để duy trì hiệu suất làm việc tốt nhất'),
('5c28ddbb-358e-45e6-b1d1-b451dc504a94', N'Vệ sinh và xử lý rò rỉ nước', N'Vệ sinh và xử lý rò rỉ nước trong hệ thống máy lạnh để đảm bảo hoạt động hiệu quả'),
('a82e981e-5df8-496b-9985-12cd638d1a13', N'Kiểm tra và điều chỉnh áp suất', N'Kiểm tra và điều chỉnh áp suất của hệ thống máy lạnh để đảm bảo hoạt động ổn định'),
('735a7f99-bc24-48a7-b2f8-140957b0b9eb', N'Kiểm tra và làm sạch cánh quạt', N'Kiểm tra và làm sạch cánh quạt của máy lạnh để đảm bảo tuổi thọ và hiệu suất của máy'); 
