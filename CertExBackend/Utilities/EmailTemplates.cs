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
