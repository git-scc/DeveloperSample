import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = (props) => {
	const [filter, setFilter] = useState("");

	const attempts = Array.isArray(props.attempts) ? props.attempts : [];
	const normalizedQuery = filter.trim().toLowerCase();
	const filteredAttempts = normalizedQuery
		? attempts.filter(a => (a.login || "").toLowerCase().includes(normalizedQuery))
		: attempts;

	return (
		<div className="Attempt-List-Main">
			<p>Recent activity</p>
			<input 
				type="input" 
				placeholder="Filter..." 
				value={filter}
				onChange={(e) => setFilter(e.target.value)}
			/>
			<ul className="Attempt-List">
				{filteredAttempts.length === 0 ? (
					<LoginAttempt>No attempts found</LoginAttempt>
				) : (
					filteredAttempts.map((attempt, index) => (
						<LoginAttempt key={index}>
							<strong>{attempt.login || "(no name)"}</strong>
							{attempt.timestamp ? ` — ${new Date(attempt.timestamp).toLocaleString()}` : ""}
						</LoginAttempt>
					))
				)}
			</ul>
		</div>
	);
};

export default LoginAttemptList;
