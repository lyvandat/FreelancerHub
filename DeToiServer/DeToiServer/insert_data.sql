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

INSERT INTO [ServiceTypes] ([Id], [Name], [Description], [BasePrice], [Image], [AddressRequireOption], [ServiceCategoryId], [Keys]) VALUES
('8b1f70d8-f765-4cff-8f70-e0b3407abcc2', N'Giải bài tập bậc đại học online', '', 0, 'services/hoctap/daihoctructiep.jpg', 'none', '6f57d993-eb26-4b35-8c7d-7871a7fd624f', N'["giải bài tập","bậc đại học","online","dịch vụ học tập","gia sư","dạy kèm","giải đáp bài tập","bài tập đại học","dịch vụ giảng dạy","gia sư đại học","dạy kèm đại học","giải bài tập đại học","giải bài tập đại học online","dịch vụ giải bài tập đại học","dịch vụ gia sư đại học"]'),
('1fd6800d-d81f-4f73-945a-3fee4e076331', N'Giải bài tập bậc đại học gặp mặt trực tiếp', '', 0, 'services/hoctap/daihoconline.jpg', 'destination', '6f57d993-eb26-4b35-8c7d-7871a7fd624f', N'["giải bài tập","bậc đại học","gặp mặt trực tiếp","dịch vụ học tập","gia sư","dạy kèm","giải đáp bài tập","bài tập đại học","gặp gỡ trực tiếp","dịch vụ giảng dạy","gia sư đại học","dạy kèm đại học","giải bài tập đại học","giảng dạy trực tiếp","hướng dẫn bài tập","giải đáp bài tập đại học","dịch vụ giải bài tập đại học","dịch vụ gia sư đại học"]'),
('8b8565e4-3629-45fa-8a02-2a3cc223189f', N'Giải bài tập THCS online', '', 0, 'services/hoctap/thcsonline.jpg', 'none', '6f57d993-eb26-4b35-8c7d-7871a7fd624f', N'["giải bài tập","trung học cơ sở","THCS","online","dịch vụ học tập","hỗ trợ học tập","làm bài tập online","giải đáp bài tập","học trực tuyến","học online","trợ giúp học tập","tham khảo bài tập","tài liệu học tập online","hướng dẫn làm bài tập","bài tập trực tuyến","giải bài tập trung học cơ sở","dịch vụ hỗ trợ học tập online"]'),
('fdb466e5-a983-43d2-bc98-b2d890148907', N'Giải bài tập THCS gặp mặt trực tiếp', '', 0, 'services/hoctap/thcstructiep.jpg', 'destination', '6f57d993-eb26-4b35-8c7d-7871a7fd624f', N'["giải bài tập","thcs","gặp mặt trực tiếp","dịch vụ học tập","gia sư","dạy kèm","giải đáp bài tập","bài tập trung học cơ sở","dịch vụ giảng dạy","gia sư thcs","dạy kèm thcs","giải bài tập thcs","giải bài tập thcs trực tiếp","dịch vụ giải bài tập thcs","dịch vụ gia sư thcs"]'),
('39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9', N'Giải bài tập THPT online', '', 0, 'services/hoctap/thptonline.jpg', 'none', '6f57d993-eb26-4b35-8c7d-7871a7fd624f', N'["giải bài tập","thpt","online","dịch vụ học tập","gia sư","dạy kèm","giải đáp bài tập","bài tập trung học phổ thông","dịch vụ giảng dạy","gia sư thpt","dạy kèm thpt","giải bài tập thpt","giải bài tập thpt online","dịch vụ giải bài tập thpt","dịch vụ gia sư thpt"]'),
('eb765dba-ccb7-49f7-b43d-04ea15558ed4', N'Giải bài tập THPT gặp mặt trực tiếp', '', 0, 'services/hoctap/thpttructiep.jpg', 'destination', '6f57d993-eb26-4b35-8c7d-7871a7fd624f', N'["Giải bài tập THPT","Gặp mặt trực tiếp","Dịch vụ hỗ trợ học tập","Gia sư","Dạy kèm","Hỗ trợ học tập","Gia sư trực tiếp","Dạy kèm trực tiếp","Hỗ trợ học tập trực tiếp","Giải bài tập trực tiếp","Làm bài tập THPT","Hỗ trợ học THPT","Gia sư THPT","Dạy kèm THPT","Giải bài tập THPT online","Gặp mặt trực tuyến","Dịch vụ hỗ trợ học tập online","Gia sư online","Dạy kèm online","Hỗ trợ học tập online","Gia sư trực tuyến","Dạy kèm trực tuyến","Hỗ trợ học tập trực tuyến","Giải bài tập trực tuyến","Làm bài tập THPT online","Hỗ trợ học THPT online","Gia sư THPT online","Dạy kèm THPT online"]'),
('d44290b5-9fa0-42c0-b5cf-f2e9980721b8', N'Đi chợ truyền thống', '', 0, 'services/dichomuadoho/market.jpg', 'destination', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e', N'["đi chợ","chợ truyền thống","dịch vụ đi chợ","dịch vụ mua đồ hộ","đi chợ hộ","mua hàng tại chợ","mua đồ tại chợ truyền thống","dịch vụ mua sắm tại chợ","dịch vụ mua hàng tại chợ truyền thống"]'),
('1b1587c7-13d1-4606-a8b1-76cc1f05093a', N'Đi siêu thị / siêu thị mini', '', 0, 'services/dichomuadoho/supermarket.jpg', 'destination', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e', N'["đi siêu thị","siêu thị mini","dịch vụ đi chợ","dịch vụ mua đồ hộ","mua hàng siêu thị","mua đồ siêu thị mini","dịch vụ mua sắm siêu thị","dịch vụ mua hàng tạp hóa","đi chợ hộ","mua đồ hộ","mua sắm hộ","mua hàng tạp hóa","đi siêu thị hộ","đi siêu thị mini hộ","dịch vụ mua sắm tại siêu thị","dịch vụ mua sắm tại siêu thị mini","mua hàng tại siêu thị","mua hàng tại siêu thị mini"]'),
('f3d729cb-0a23-4369-aad5-2c2cb9e94ebf', N'Ngon và rẻ', '', 0, 'services/dichomuadoho/market.jpg', 'destination', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e', N'["Ngon và rẻ","Dịch vụ Đi chợ","Mua đồ hộ","Dịch vụ mua sắm","Dịch vụ mua hàng","Dịch vụ mua đồ","Dịch vụ mua đồ tiêu dùng","Mua sắm trực tuyến","Đi chợ trực tuyến","Dịch vụ giao hàng","Dịch vụ mua đồ tại nhà","Dịch vụ mua hàng tại nhà","Dịch vụ đặt mua hàng","Dịch vụ đặt mua đồ","Đi chợ online","Mua đồ tiện lợi","Mua hàng online","Dịch vụ mua sắm online","Dịch vụ giao hàng nhanh","Mua đồ hàng ngày","Dịch vụ tiện ích mua sắm"]'),
('95e967ae-68f4-4a40-8fc7-8073014430ed', N'Mua sắm hộ', '', 0, 'services/dichomuadoho/market.jpg', 'shipping', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e', N'["mua sắm","mua hàng","mua hộ","dịch vụ đi chợ","dịch vụ mua đồ hộ","mua sắm hộ","mua hàng hộ","đi chợ hộ","mua đồ hộ"]'),
('7f00c28b-87cd-47fe-a736-157118091675', N'Mua thuốc hộ', '', 0, 'services/dichomuadoho/market.jpg', 'shipping', 'd17ad87c-9f80-4f0e-bfd4-53138d900a6e', N'["mua thuốc","dịch vụ mua thuốc","đi chợ","mua đồ","mua đồ hộ","dịch vụ đi chợ","mua thuốc online","dịch vụ mua sắm","mua sắm hộ","dịch vụ giao hàng thuốc","mua thuốc cho người khác","dịch vụ mua thuốc online","giao thuốc tận nhà","dịch vụ mua sắm tận nhà","dịch vụ mua thuốc tận nhà"]'),
('25c9c567-5119-4140-a70b-5c3a1d1c3250', N'Chơi game chung theo giờ', '', 0, 'services/dichomuadoho/market.jpg', 'none', '8a21b21e-dc31-49c8-8b5b-84b69204dc3a', N'["chơi game","chung","theo giờ","dịch vụ giải trí","game online","chơi game cùng nhau","chơi game theo giờ","dịch vụ chơi game","dịch vụ game trực tuyến","chơi game theo số giờ","dịch vụ chơi game chung","dịch vụ chơi game theo giờ","game giải trí","chơi game giải trí","chơi game cùng nhau theo giờ","dịch vụ chơi game giải trí theo giờ"]'),
('6ee8adfe-323c-4648-aa94-37f6ece6083f', N'Chơi game chung theo số trận', '', 0, 'services/dichomuadoho/market.jpg', 'none', '8a21b21e-dc31-49c8-8b5b-84b69204dc3a', N'["chơi game","chung","số trận","dịch vụ giải trí","game online","chơi game cùng nhau","chơi game theo trận","dịch vụ chơi game","dịch vụ game trực tuyến","chơi game theo số lượng trận","dịch vụ chơi game chung","dịch vụ chơi game theo trận","dịch vụ chơi game theo số trận","game giải trí","chơi game giải trí","chơi game cùng nhau theo trận","chơi game cùng nhau theo số trận","dịch vụ chơi game giải trí theo trận","dịch vụ chơi game giải trí theo số trận"]'),
('cb217b7f-f921-4568-8d1c-bf891f6b38f0', N'Gửi đồ hộ', '', 0, 'services/vanchuyen/guidoho.jpg', 'shipping', '1b1a6ebd-2838-4b3d-a1f1-1818305df2d6', N'["gửi đồ","gửi hàng","gửi hộ","dịch vụ vận chuyển","dịch vụ giao hàng","gửi đồ hộ","gửi hàng hộ","vận chuyển đồ","vận chuyển hàng hóa"]'),
('96a7c6f2-73c2-4330-9629-c3441598ab94', N'Chuyển nhà trọn gói', '', 0, 'services/vanchuyen/chuyennhatrongoi.jpg', 'shipping', '1b1a6ebd-2838-4b3d-a1f1-1818305df2d6', N'["chuyển nhà","trọn gói","dịch vụ vận chuyển","dịch vụ giao hàng","chuyển nhà trọn gói","dịch vụ chuyển nhà","dịch vụ chuyển nhà trọn gói","vận chuyển đồ đạc","vận chuyển nhà cửa"]'),
('5a47d275-cd05-4521-9fe4-3aebbc8af90d', N'Chuyển phòng trọ trọn gói', '', 0, 'services/vanchuyen/chuyenphongtrotrongoi.jpg', 'shipping', '1b1a6ebd-2838-4b3d-a1f1-1818305df2d6', N'["chuyển","phòng trọ","trọn gói","dịch vụ","vận chuyển","chuyển nhà","chuyển đồ","dọn nhà","dịch vụ dọn nhà","dịch vụ chuyển nhà","chuyển phòng","chuyển phòng trọ","chuyển đồ đạc","vận chuyển đồ đạc","dịch vụ vận chuyển đồ","dịch vụ vận chuyển đồ đạc","dịch vụ chuyển phòng trọ","dịch vụ chuyển phòng trọ trọn gói"]'),
('20393b46-1f86-48ee-90e5-f8c20b90ff7a', N'Tư vấn tâm lý', '', 0, 'services/tuvanhoidap/tuvantamly.jpg', 'none', 'a4676a9d-7dfb-4d23-8cb5-8e2678c4c611', N'["tư vấn tâm lý","dịch vụ tư vấn","dịch vụ hỏi đáp","dịch vụ giải đáp thắc mắc","tư vấn tâm lý trực tuyến","tư vấn sức khỏe tâm thần","dịch vụ tư vấn tâm lý","dịch vụ tư vấn sức khỏe tâm thần"]'),
('c2523753-a16d-4839-910f-03b224019649', N'Giải đáp thắc mắc', '', 0, 'services/tuvanhoidap/giaidapthacmac.jpg', 'none', 'a4676a9d-7dfb-4d23-8cb5-8e2678c4c611', N'["Tư vấn","Dịch vụ","Giải đáp","Thắc mắc","Hỗ trợ","Tư vấn viên","Chuyên gia","Tư vấn trực tuyến","Tư vấn cá nhân","Tư vấn doanh nghiệp","Tư vấn tài chính","Tư vấn pháp lý","Tư vấn sức khỏe","Tư vấn hôn nhân","Tư vấn giáo dục","Tư vấn nghề nghiệp","Tư vấn kinh doanh","Tư vấn du lịch","Tư vấn công nghệ","Tư vấn sản phẩm"]'); 

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

INSERT INTO [UIElementInputMethodTypes] ([Id], [Name]) VALUES
('265db114-09e5-431e-bf24-e735b87577f2', 'input'),
('8e8ca369-e98c-4b8a-ac89-974ac1392e1f', 'special_item_select'),
('640b4e24-a1c1-486e-a7b6-b48d8a23430c', 'input'),
('68587c28-45c1-4adc-ba81-fadf3469cbec', 'input'),
('3f00c399-f12d-4840-9e99-f5e40a8fc223', 'special_item_select'),
('91a22d20-a4ce-442b-bc43-bacc2e6ce729', 'input'),
('e602bb8f-ddce-4d94-881a-0ed39f33bf0e', 'select'),
('93c81736-1b81-4d92-8c3a-827f1672d82b', 'special_item_select'),
('7bf319eb-14da-49d4-8c57-a41ca7ea6f5e', 'input'),
('613af249-d5bb-444d-a21f-0ec8af9ac85d', 'select'),
('799d312b-c329-450c-ba2f-26660d7032fb', 'special_item_select'),
('b65c140e-6615-43b6-9ba1-df6bf9ad6cec', 'input'),
('0f70b540-9985-4fa1-90a6-49d49662c9f5', 'select'),
('b0bbde0b-bdfe-4805-a774-853a279cfc12', 'special_item_select'),
('76674959-6a29-4c98-977e-261c9068b0d5', 'input'),
('1a561ca5-3054-4b36-ac4a-f9d31ca41d6a', 'select'),
('94cffacc-4d29-4c1c-a7ad-3edaac293ebc', 'special_item_select'),
('ad214b46-c368-4c55-856b-580d322b4430', 'input'); 

INSERT INTO [UIElementServiceRequirementInputMethods] ([Id], [DataType], [MethodId]) VALUES
('3aaae33e-3be8-486e-b7fe-1f8af36471be', 'text', '265db114-09e5-431e-bf24-e735b87577f2'),
('53d2ac83-522b-4fd9-9152-aa26ea9ba1d5', 'text', '8e8ca369-e98c-4b8a-ac89-974ac1392e1f'),
('9199228c-dec7-45e8-b8ac-e5b569829166', 'text', '640b4e24-a1c1-486e-a7b6-b48d8a23430c'),
('dd9c7759-fc6c-458a-9a8d-2f2e19cbccfc', 'text', '68587c28-45c1-4adc-ba81-fadf3469cbec'),
('47335b2d-94e8-4e37-971a-99d0a24385c0', 'text', '3f00c399-f12d-4840-9e99-f5e40a8fc223'),
('91ff286d-afa7-44f8-a057-61765f9d2541', 'text', '91a22d20-a4ce-442b-bc43-bacc2e6ce729'),
('902874ad-a50e-4212-aa5e-0b1eee20c3e2', 'text', 'e602bb8f-ddce-4d94-881a-0ed39f33bf0e'),
('2a8b0a34-d0db-4769-9a7a-76e9fa43a803', 'text', '93c81736-1b81-4d92-8c3a-827f1672d82b'),
('e83aaeb3-ae9d-4822-8419-a7b2448eca8c', 'text', '7bf319eb-14da-49d4-8c57-a41ca7ea6f5e'),
('feb81020-b12b-4914-9f09-50ac4e0be871', 'text', '613af249-d5bb-444d-a21f-0ec8af9ac85d'),
('eb58c4b5-e18f-45e4-a8c5-32a89be2e559', 'text', '799d312b-c329-450c-ba2f-26660d7032fb'),
('577c7fa1-4a5b-4239-8f66-703ca9e2b13f', 'text', 'b65c140e-6615-43b6-9ba1-df6bf9ad6cec'),
('03a21214-0843-49e5-907f-87f13986df4e', 'text', '0f70b540-9985-4fa1-90a6-49d49662c9f5'),
('8698a0ca-1480-4dd5-8190-7d79d8fc5df3', 'text', 'b0bbde0b-bdfe-4805-a774-853a279cfc12'),
('6ab57865-0d65-4a3e-9a6d-4a502eb0feb9', 'text', '76674959-6a29-4c98-977e-261c9068b0d5'),
('cf974ebf-2e16-4c76-a153-dbb8b1196107', 'text', '1a561ca5-3054-4b36-ac4a-f9d31ca41d6a'),
('418b6a77-d45b-4fd7-ac11-df9b23bd7106', 'text', '94cffacc-4d29-4c1c-a7ad-3edaac293ebc'),
('bd0f1fe1-c30a-4762-902e-12cbd5a9d753', 'text', 'ad214b46-c368-4c55-856b-580d322b4430'); 

INSERT INTO [UIElementValidationTypes] ([Id], [Name], [Message], [InputMethodId], [Value]) VALUES
('e929163b-46b6-4425-ba43-b660ddfb1c20', 'required', N'Bạn chưa nhập tên môn học', '3aaae33e-3be8-486e-b7fe-1f8af36471be', null),
('8375740d-96ac-4108-8238-e828d311ac67', 'max', N'Không quá 1000 ký tự', '3aaae33e-3be8-486e-b7fe-1f8af36471be', 1000),
('8b87f6cd-3b81-42a0-b7c2-9e33b33c03b7', 'required', N'Không được để trống hình thức', '53d2ac83-522b-4fd9-9152-aa26ea9ba1d5', null),
('2340ce3a-861b-4932-b3c6-b1e3600ab1e5', 'max', N'Không quá 1000 ký tự', '9199228c-dec7-45e8-b8ac-e5b569829166', 1000),
('7e66c67f-2cfd-4eaa-8106-b821aadda1a0', 'required', N'Bạn chưa nhập tên môn học', 'dd9c7759-fc6c-458a-9a8d-2f2e19cbccfc', null),
('20a00b50-86ca-4c70-98b1-f7d2e9715734', 'max', N'Không quá 1000 ký tự', 'dd9c7759-fc6c-458a-9a8d-2f2e19cbccfc', 1000),
('989a792a-17ee-4cf1-bfca-336a4ee221bf', 'required', N'Không được để trống hình thức', '47335b2d-94e8-4e37-971a-99d0a24385c0', null),
('a41ceaa2-e079-4e5f-8c25-7eb2bb28ee1f', 'max', N'Không quá 1000 ký tự', '91ff286d-afa7-44f8-a057-61765f9d2541', 1000),
('0bf39f80-8aea-4729-8eb0-941cc2642d38', 'required', N'Không được để trống môn học', '902874ad-a50e-4212-aa5e-0b1eee20c3e2', null),
('124dcc85-66ed-4b66-b6d9-d08e1a123d14', 'required', N'Không được để trống hình thức', '2a8b0a34-d0db-4769-9a7a-76e9fa43a803', null),
('5cfa7b42-8223-4f27-97df-069721b417e0', 'max', N'Không quá 1000 ký tự', 'e83aaeb3-ae9d-4822-8419-a7b2448eca8c', 1000),
('cf595c08-6093-40fa-b31b-aec7eb9dcc7c', 'required', N'Không được để trống môn học', 'feb81020-b12b-4914-9f09-50ac4e0be871', null),
('fe2cbcca-4fb6-4a93-bbe2-5b9c567db029', 'required', N'Không được để trống hình thức', 'eb58c4b5-e18f-45e4-a8c5-32a89be2e559', null),
('2b31e1b0-a976-4d4f-b52e-f5caf75ebd3c', 'max', N'Không quá 1000 ký tự', '577c7fa1-4a5b-4239-8f66-703ca9e2b13f', 1000),
('1b9bff5b-a12e-4531-8964-4b41a04edfcc', 'required', N'Không được để trống môn học', '03a21214-0843-49e5-907f-87f13986df4e', null),
('995e756e-bf1b-4d67-84e0-185a6fa00793', 'required', N'Không được để trống hình thức', '8698a0ca-1480-4dd5-8190-7d79d8fc5df3', null),
('88a2f25b-ebf9-4476-bae7-19233de45565', 'max', N'Không quá 1000 ký tự', '6ab57865-0d65-4a3e-9a6d-4a502eb0feb9', 1000),
('14b9884e-3a4f-436e-afb1-ab6bc2b04ebb', 'required', N'Không được để trống môn học', 'cf974ebf-2e16-4c76-a153-dbb8b1196107', null),
('68f3677f-a2e2-4807-9643-367b1f70d83c', 'required', N'Không được để trống hình thức', '418b6a77-d45b-4fd7-ac11-df9b23bd7106', null),
('941e2381-9080-4433-9ab6-65b8f12d7881', 'max', N'Không quá 1000 ký tự', 'bd0f1fe1-c30a-4762-902e-12cbd5a9d753', 1000); 

INSERT INTO [UIElementServiceRequirements] ([Id], [Label], [LabelIcon], [Placeholder], [InputMethodId], [Key], [Priority], [ServiceTypeId]) VALUES
('b553cf2c-41a8-44c6-87a3-52043a5c4a7d', N'Môn học', 'faBook', N'Ví dụ: Kinh tế vĩ mô', '3aaae33e-3be8-486e-b7fe-1f8af36471be', 'mon_hoc', 0, '8b1f70d8-f765-4cff-8f70-e0b3407abcc2'),
('b8309b0b-b191-4c7a-8f32-a3130343f413', N'Hình thức', 'faLayerGroup', N'Bạn muốn giải bài tập theo hình thức nào?', '53d2ac83-522b-4fd9-9152-aa26ea9ba1d5', 'hinh_thuc', 1, '8b1f70d8-f765-4cff-8f70-e0b3407abcc2'),
('5585e790-0bae-497b-919f-b24621027ab5', N'Mô tả thêm (nếu có)', null, N'Thêm mô tả để nhân viên hiểu hơn nhé', '9199228c-dec7-45e8-b8ac-e5b569829166', 'mo_ta_them_(neu_co)', 2, '8b1f70d8-f765-4cff-8f70-e0b3407abcc2'),
('4e893dd4-e5e6-4e27-b16e-f6dbf6f162bb', N'Môn học', 'faBook', N'Ví dụ: Kinh tế vĩ mô', 'dd9c7759-fc6c-458a-9a8d-2f2e19cbccfc', 'mon_hoc', 0, '1fd6800d-d81f-4f73-945a-3fee4e076331'),
('98751e53-cd79-4d92-8505-b5cd8d98342e', N'Hình thức', 'faLayerGroup', N'Bạn muốn giải bài tập theo hình thức nào?', '47335b2d-94e8-4e37-971a-99d0a24385c0', 'hinh_thuc', 1, '1fd6800d-d81f-4f73-945a-3fee4e076331'),
('c292b6da-544e-47eb-9f82-8b7a1c091192', N'Mô tả thêm (nếu có)', null, N'Thêm mô tả để nhân viên hiểu hơn nhé', '91ff286d-afa7-44f8-a057-61765f9d2541', 'mo_ta_them_(neu_co)', 2, '1fd6800d-d81f-4f73-945a-3fee4e076331'),
('21142197-05ac-4bfb-b7f0-6e7b3b55379a', N'Môn học', 'faBook', N'Chọn 1 môn học bạn muốn', '902874ad-a50e-4212-aa5e-0b1eee20c3e2', 'mon_hoc', 0, '8b8565e4-3629-45fa-8a02-2a3cc223189f'),
('54c28dd4-039d-422f-b45c-aa95d2c0b031', N'Hình thức', 'faLayerGroup', N'Bạn muốn giải bài tập theo hình thức nào?', '2a8b0a34-d0db-4769-9a7a-76e9fa43a803', 'hinh_thuc', 1, '8b8565e4-3629-45fa-8a02-2a3cc223189f'),
('c0824b55-4c03-4418-9974-c6198739a21c', N'Mô tả thêm (nếu có)', null, N'Thêm mô tả để nhân viên hiểu hơn nhé', 'e83aaeb3-ae9d-4822-8419-a7b2448eca8c', 'mo_ta_them_(neu_co)', 2, '8b8565e4-3629-45fa-8a02-2a3cc223189f'),
('24eccab3-cfda-41a0-889f-57e19cd2c131', N'Môn học', 'faBook', N'Chọn 1 môn học bạn muốn', 'feb81020-b12b-4914-9f09-50ac4e0be871', 'mon_hoc', 0, 'fdb466e5-a983-43d2-bc98-b2d890148907'),
('bd12a1fe-02d6-4718-9f66-f41bc7e0444a', N'Hình thức', 'faLayerGroup', N'Bạn muốn giải bài tập theo hình thức nào?', 'eb58c4b5-e18f-45e4-a8c5-32a89be2e559', 'hinh_thuc', 1, 'fdb466e5-a983-43d2-bc98-b2d890148907'),
('622f9f60-0c9a-4f55-be57-684cb27ccd6a', N'Mô tả thêm (nếu có)', null, N'Thêm mô tả để nhân viên hiểu hơn nhé', '577c7fa1-4a5b-4239-8f66-703ca9e2b13f', 'mo_ta_them_(neu_co)', 2, 'fdb466e5-a983-43d2-bc98-b2d890148907'),
('462b64bf-b81d-461e-a060-4083b0c19542', N'Môn học', 'faBook', N'Chọn 1 môn học bạn muốn', '03a21214-0843-49e5-907f-87f13986df4e', 'mon_hoc', 0, '39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9'),
('20e4a2bf-c10f-4e00-8ab3-154f4c0ad2c1', N'Hình thức', 'faLayerGroup', N'Bạn muốn giải bài tập theo hình thức nào?', '8698a0ca-1480-4dd5-8190-7d79d8fc5df3', 'hinh_thuc', 1, '39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9'),
('a16336e5-ac32-4cee-9a58-3e15693d8d42', N'Mô tả thêm (nếu có)', null, N'Thêm mô tả để nhân viên hiểu hơn nhé', '6ab57865-0d65-4a3e-9a6d-4a502eb0feb9', 'mo_ta_them_(neu_co)', 2, '39ee46a3-77bf-43fb-8fac-82d8ca2fc4f9'),
('58de8f86-4aec-4054-bac4-d111a296666b', N'Môn học', 'faBook', N'Chọn 1 môn học bạn muốn', 'cf974ebf-2e16-4c76-a153-dbb8b1196107', 'mon_hoc', 0, 'eb765dba-ccb7-49f7-b43d-04ea15558ed4'),
('e2393992-8414-490f-b214-6d208c3b5fb2', N'Hình thức', 'faLayerGroup', N'Bạn muốn giải bài tập theo hình thức nào?', '418b6a77-d45b-4fd7-ac11-df9b23bd7106', 'hinh_thuc', 1, 'eb765dba-ccb7-49f7-b43d-04ea15558ed4'),
('b84f10c5-0304-4115-a467-cf9492340c8e', N'Mô tả thêm (nếu có)', null, N'Thêm mô tả để nhân viên hiểu hơn nhé', 'bd0f1fe1-c30a-4762-902e-12cbd5a9d753', 'mo_ta_them_(neu_co)', 2, 'eb765dba-ccb7-49f7-b43d-04ea15558ed4'); 
