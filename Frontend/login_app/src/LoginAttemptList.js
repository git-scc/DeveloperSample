<<<<<<< HEAD
import React from "react";
=======
import React, { useState } from "react";
>>>>>>> 25d79f0 (Completed DeveloperSample assessment: frontend and backend)
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

<<<<<<< HEAD
const LoginAttemptList = (props) => (
	<div className="Attempt-List-Main">
	 	<p>Recent activity</p>
	  	<input type="input" placeholder="Filter..." />
		<ul className="Attempt-List">
			<LoginAttempt>TODO</LoginAttempt>
		</ul>
	</div>
);
=======
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
>>>>>>> 25d79f0 (Completed DeveloperSample assessment: frontend and backend)

export default LoginAttemptList;