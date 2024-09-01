namespace CertExBackend.Utilities
{
    public static class EmailTemplates
    {
        public static string CreateNominationSubmittedEmail(string certificationName, string employeeFirstName)
        {
            return $@"
<html>
<body style='font-family: Arial, sans-serif; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
        <h2 style='color: #007BFF;'>Nomination Submitted</h2>
        <p>Hi {employeeFirstName},</p>
        <p>Your nomination for the certification '<strong>{certificationName}</strong>' has been submitted successfully. You will receive an email notification once it is approved by the Department Head and L&D.</p>
        <p>Thank you,<br>Team CertEx</p>
    </div>
</body>
</html>
";
        }


        public static string CreateManagerApprovalEmail(
       string certificationName,
       string employeeName,
       string plannedExamMonth,
       string motivationDescription,
       string managerName,
       string approvalUrl)
        {
            return $@"
<html>
<body style='font-family: Arial, sans-serif; color: #333; margin: 0; padding: 0;'>
    <div style='max-width: 600px; margin: 20px auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px; background-color: #f9f9f9;'>
        <h2 style='color: #007BFF; font-size: 24px; margin-top: 0;'>Review Nomination</h2>
        <p>Hi {managerName},</p>
        <p>The employee <strong>{employeeName}</strong> has submitted a nomination for the certification '<strong>{certificationName}</strong>'.</p>
        <p><strong>Planned Exam Month:</strong> {plannedExamMonth}</p>
        <p><strong>Motivation Description:</strong></p>
        <blockquote style='border-left: 4px solid #007BFF; padding-left: 10px; margin: 10px 0; font-style: italic;'>{motivationDescription}</blockquote>
        <p>To review this nomination, please click the button below:</p>
        <a href='{approvalUrl}' style='display: inline-block; padding: 10px 20px; font-size: 16px; color: #fff; background-color: #007BFF; text-decoration: none; border-radius: 4px;'>Review Nomination</a>
        <p style='margin-top: 20px;'>Thank you,<br>Team CertEx</p>
    </div>
</body>
</html>
";
        }




        public static string CreateDepartmentApprovalEmail(string certificationName, string employeeName, string plannedExamMonth, string motivationDescription, string managerName, string managerRecommendation, string managerRemarks, string approveUrl, string rejectUrl)
        {
            return $@"
<html>
<body style='font-family: Arial, sans-serif; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
        <h2 style='color: #007BFF;'>Nomination Awaiting Your Approval</h2>
        <p>Hi,</p>
        <p>A nomination has been submitted for the certification '<strong>{certificationName}</strong>'.</p>
        <p><strong>Employee:</strong> {employeeName}</p>
        <p><strong>Planned Exam Month:</strong> {plannedExamMonth}</p>
        <p><strong>Motivation:</strong> {motivationDescription}</p>
        <p><strong>Manager Name:</strong> {managerName}</p>
        <p><strong>Manager Recommendation:</strong> {managerRecommendation}</p>
        <p><strong>Manager Remarks:</strong> {managerRemarks}</p>
        <div style='margin-top: 20px;'>
            <a href='{approveUrl}' style='display: inline-block; padding: 10px 20px; margin-right: 10px; text-decoration: none; color: #fff; background-color: #28a745; border-radius: 4px;'>Approve</a>
            <a href='{rejectUrl}' style='display: inline-block; padding: 10px 20px; text-decoration: none; color: #fff; background-color: #dc3545; border-radius: 4px;'>Reject</a>
        </div>
        <p>Thank you,<br>Team CertEx</p>
    </div>
</body>
</html>
";
        }


        public static string CreateLndApprovalEmail(
    string certificationName,
    string employeeName,
    string plannedExamMonth,
    string motivationDescription,
    string managerName,
    string managerRecommendation,
    string managerRemarks,
    bool isDepartmentApproved,
    string approveUrl,
    string rejectUrl
)
        {
            var departmentApprovalStatus = isDepartmentApproved ? "approved" : "rejected";

            return $@"
<html>
<body style='font-family: Arial, sans-serif; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
        <h2 style='color: #007BFF;'>Nomination Awaiting Your Final Approval</h2>
        <p>Hi,</p>
        <p>A nomination for the certification '<strong>{certificationName}</strong>' is awaiting your final approval.</p>
        <p><strong>Employee:</strong> {employeeName}</p>
        <p><strong>Planned Exam Month:</strong> {plannedExamMonth}</p>
        <p><strong>Motivation:</strong> {motivationDescription}</p>
        <p><strong>Manager Name:</strong> {managerName}</p>
        <p><strong>Manager Recommendation:</strong> {managerRecommendation}</p>
        <p><strong>Manager Remarks:</strong> {managerRemarks}</p>
        <p><strong>Department Head Approval Status:</strong> {departmentApprovalStatus}</p>
        <div style='margin-top: 20px;'>
            <a href='{approveUrl}' style='display: inline-block; padding: 10px 20px; margin-right: 10px; text-decoration: none; color: #fff; background-color: #28a745; border-radius: 4px;'>Approve</a>
            <a href='{rejectUrl}' style='display: inline-block; padding: 10px 20px; text-decoration: none; color: #fff; background-color: #dc3545; border-radius: 4px;'>Reject</a>
        </div>
        <p>Thank you,<br>Team CertEx</p>
    </div>
</body>
</html>
";
        }

        public static string CreateAwsAdminEmail(
    string certificationName,
    string employeeName,
    string employeeEmail,
    string plannedExamMonth,
    string awsCredentialsUrl
)
        {
            return $@"
<html>
<body style='font-family: Arial, sans-serif; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
        <h2 style='color: #007BFF;'>AWS Certification - Action Required</h2>
        <p>Hi,</p>
        <p>The following AWS certification has been approved and requires your attention:</p>
        <p><strong>Certification Name:</strong> {certificationName}</p>
        <p><strong>Employee:</strong> {employeeName}</p>
        <p><strong>Employee Email:</strong> {employeeEmail}</p>
        <p><strong>Planned Exam Month:</strong> {plannedExamMonth}</p>
        <div style='margin-top: 20px;'>
            <a href='{awsCredentialsUrl}' style='display: inline-block; padding: 10px 20px; text-decoration: none; color: #fff; background-color: #007bff; border-radius: 4px;'>Provide AWS Credentials</a>
        </div>
        <p>Thank you,<br>Team CertEx</p>
    </div>
</body>
</html>
";
        }


        public static string CreateAwsCredentialsEmail(
        string awsCredentials,
        string awsAdminRemarks)
        {
            return $@"
<html>
<body style='font-family: Arial, sans-serif; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
        <h2 style='color: #007BFF;'>AWS Credentials and Access Details</h2>
        <p>Hi,</p>
        <p>Your AWS account credentials have been successfully created.</p>
        <p><strong>AWS Credentials:</strong> {awsCredentials}</p>
        <p><strong>Remarks from AWS Admin:</strong></p>
        <blockquote style='border-left: 4px solid #007BFF; padding-left: 10px; font-style: italic; color: #555;'>
            {awsAdminRemarks}
        </blockquote>
        <p>If you face any trouble or have further queries, please reply to this email. Your response will be directed to the AWS Admin for further assistance.</p>
        <p>Thank you,<br>Team CertEx</p>
    </div>
</body>
</html>
";
        }
        public static string CreateManagerNotificationEmail(string employeeName, string certificationName, string managerFirstName)
        {
            return $@"
<html>
<body style='font-family: Arial, sans-serif; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
        <h2 style='color: #007BFF;'>Employee Nomination Submitted</h2>
        <p>Hi {managerFirstName},</p>
        <p>The employee <strong>{employeeName}</strong> has submitted a nomination for the certification '<strong>{certificationName}</strong>'. Please review and approve or reject the nomination as soon as possible.</p>
        <p>Thank you,<br>Team CertEx</p>
    </div>
</body>
</html>
";
        }

        public static string CreateApprovalRequestEmail(string certificationName, string employeeName, string plannedExamMonth, string motivationDescription, string approveUrl, string rejectUrl, string approverType)
        {
            return $@"
<html>
<body style='font-family: Arial, sans-serif; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
        <h2 style='color: #007BFF;'>Nomination Awaiting {approverType} Approval</h2>
        <p>Hi,</p>
        <p>A nomination has been submitted for the certification '<strong>{certificationName}</strong>'.</p>
        <p><strong>Employee:</strong> {employeeName}</p>
        <p><strong>Planned Exam Month:</strong> {plannedExamMonth}</p>
        <p><strong>Motivation:</strong> {motivationDescription}</p>
        <div style='margin-top: 20px;'>
            <a href='{approveUrl}' style='display: inline-block; padding: 10px 20px; margin-right: 10px; text-decoration: none; color: #fff; background-color: #28a745; border-radius: 4px;'>Approve</a>
            <a href='{rejectUrl}' style='display: inline-block; padding: 10px 20px; text-decoration: none; color: #fff; background-color: #dc3545; border-radius: 4px;'>Reject</a>
        </div>
        <p>Thank you,<br>Team CertEx</p>
    </div>
</body>
</html>
";
        }


        public static string CreateStatusUpdateEmail(string certificationName, string status, string employeeFirstName)
        {
            return $@"
<html>
<body style='font-family: Arial, sans-serif; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
        <h2 style='color: #007BFF;'>Nomination {status}</h2>
        <p>Hi {employeeFirstName},</p>
        <p>Your nomination for the certification '<strong>{certificationName}</strong>' has been {status}.</p>
        <p>Thank you,<br>Team CertEx</p>
    </div>
</body>
</html>
";
        }
    }
}
